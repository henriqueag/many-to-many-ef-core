using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcFilterApi.Controllers;

[ApiController]
[Route("api/security")]
public class SecurityController : ControllerBase
{
    private UserManager<AppUser> userManager;
    private SignInManager<AppUser> signInManager;

    public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
    {
        userManager = userMgr;
        signInManager = signinMgr;
    }

    [AllowAnonymous]
    public IActionResult GoogleLogin()
    {
        string redirectUrl = Url.Action("GoogleResponse", "Account");
        var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        return new ChallengeResult("Google", properties);
    }

    [AllowAnonymous]
    public async Task<IActionResult> GoogleResponse()
    {
        return Ok();
        // ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
        // if (info == null)
        //     return RedirectToAction(nameof(Login));

        // var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        // string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
        // if (result.Succeeded)
        //     return View(userInfo);
        // else
        // {
        //     AppUser user = new AppUser
        //     {
        //         Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
        //         UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
        //     };

        //     IdentityResult identResult = await userManager.CreateAsync(user);
        //     if (identResult.Succeeded)
        //     {
        //         identResult = await userManager.AddLoginAsync(user, info);
        //         if (identResult.Succeeded)
        //         {
        //             await signInManager.SignInAsync(user, false);
        //             return View(userInfo);
        //         }
        //     }
        //     return AccessDenied();
        // }
    }
}
