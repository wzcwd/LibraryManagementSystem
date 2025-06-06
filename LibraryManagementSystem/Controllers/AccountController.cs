using System.Security.Claims;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels.Account;
using LibraryManagementSystem.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly ILogger<AccountController> logger;
    private readonly SendGridEmailSender _emailSender;

    public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr, ILogger<AccountController> log,
        SendGridEmailSender emailSender)
    {
        userManager = userMngr;
        signInManager = signInMngr;
        logger = log;
        _emailSender = emailSender;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = "/")
    {
        LoginViewModel model = new LoginViewModel
        {
            ReturnUrl = returnUrl
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken] //  avoid CSRF attack
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await signInManager.PasswordSignInAsync(
            model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            logger.LogInformation("User '{Username}' logged in successfully at {Time}.", model.Username, DateTime.Now);
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        logger.LogWarning("Login failed for user '{Username}' at {Time}.", model.Username, DateTime.Now);
        ModelState.AddModelError(string.Empty, "Invalid login, please try again.");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken] //  avoid CSRF attack
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        logger.LogInformation("logged out successfully");
        return RedirectToAction(nameof(Login), "Account");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new User
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            logger.LogInformation("New user '{Username}' registered successfully at {Time}.", model.Username,
                DateTime.Now);
            await signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    public IActionResult ExternalLogin(string provider, string returnUrl = "/")
    {
        var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", returnUrl);
        var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return Challenge(properties, provider); // go the third-party Authentication plateform
    }

    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/", string? remoteError = null)
    {
        if (remoteError != null)
        {
            ModelState.AddModelError(string.Empty, $"External provider error: {remoteError}");
            return RedirectToAction(nameof(Login));
        }

        var info = await signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            return RedirectToAction(nameof(Login));
        }

        // try to log in 
        var result =
            await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
        if (result.Succeeded)
        {
            return Redirect(returnUrl);
        }

        // check if the email already exists
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var user = await userManager.FindByEmailAsync(email!);
        if (user == null)
        {
            // if user does not exist, create new user
            user = new User { UserName = email, Email = email };
            var createResult = await userManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                await userManager.AddLoginAsync(user, info);
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect(returnUrl);
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        else
        {
            // user(email) exists but external login not linked, so link it
            var addLoginResult = await userManager.AddLoginAsync(user, info);
            if (addLoginResult.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect(returnUrl);
            }

            foreach (var error in addLoginResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View("Login");
    }


    [Authorize]
    public async Task<IActionResult> UpdateAccount()
    {
        // get user
        var user = await userManager.GetUserAsync(User);
        logger.LogInformation("User '{UserName}' is accessing the account update page.", user.UserName);

        var model = new AccountViewModel()
        {
            Username = user.UserName!,
            Email = user.Email!
        };

        return View("AccountInfo", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> UpdateAccount(AccountViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("AccountInfo", model);
        }

        // get user
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            throw new Exception("We can't find the user, please contact the administrator.");
        }

        // Check if new username is taken by another user
        var existingUser = await userManager.FindByNameAsync(model.Username);
        if (existingUser != null && existingUser.Id != user.Id)
        {
            ModelState.AddModelError("Username", "This username is already taken.");
            return View("AccountInfo", model);
        }

        // Check if new email is taken by another user
        var existingUserByEmail = await userManager.FindByEmailAsync(model.Email);
        if (existingUserByEmail != null && existingUserByEmail.Id != user.Id)
        {
            ModelState.AddModelError("Email", "This email is already in use.");
            return View("AccountInfo", model);
        }

        // update user info
        user.UserName = model.Username;
        user.Email = model.Email;
        var result = await userManager.UpdateAsync(user);

        // if success, refresh the user info
        if (result.Succeeded)
        {
            await signInManager.RefreshSignInAsync(user);
            ViewData["UpdateSuccess"] = "Account updated successfully.";
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View("AccountInfo", model);
    }


    [Authorize]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(PasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.NewPassword != model.ConfirmPassword)
        {
            ModelState.AddModelError("", "New password and confirmation do not match.");
            return View(model);
        }

        // get user 
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        // verify the verification code
        // get verification code and time stamp from session
        var storedCode = HttpContext.Session.GetString("EmailVerificationCode");
        var generatedTimeString = HttpContext.Session.GetString("CodeGeneratedTime");

        if (string.IsNullOrEmpty(storedCode) || string.IsNullOrEmpty(generatedTimeString))
        {
            throw new Exception("Verification code or timestamp is missing. Session error.");
        }
        // parse time stamp
        DateTime generatedTime = DateTime.Parse(generatedTimeString);

        // verify the valid time
        // Todo: improve the hardcoding approach
        if (DateTime.UtcNow - generatedTime > TimeSpan.FromMinutes(5))
        {
            ModelState.AddModelError("", "Verification code has expired. Please request a new code.");
            return View(model);
        }

        if (model.VerificationCode != storedCode)
        {
            ModelState.AddModelError("", "Incorrect verification code.");
            return View(model);
        }

        // change password
        var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (result.Succeeded)
        {
            await signInManager.RefreshSignInAsync(user); // Refresh the login session
            ViewData["UpdateSuccess"] = "Password changed successfully.";
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View(model);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendCode()
    {
        logger.LogInformation("SendCode() action started.");
        var user = await userManager.GetUserAsync(User);
        if (user == null || string.IsNullOrEmpty(user.Email))
        {
            return Content("User not found or email is empty.");
        }

        // generate a 6-digit verification code
        var code = new Random().Next(100000, 999999).ToString();

        // store the verification code to session
        HttpContext.Session.SetString("EmailVerificationCode", code);
        // store the generate time for the code
        HttpContext.Session.SetString("CodeGeneratedTime", DateTime.UtcNow.ToString());

        var message = $"<p>Your verification code is: <strong>{code}</strong></p>";
        
        await _emailSender.SendEmailAsync(user.Email, "Your Verification Code", message);

        // Todo: improve the hardcoding approach
        int validMinutes = 5;
        return Content($"A Verification code has been sent. It is valid for {validMinutes} minutes.");
    }
}