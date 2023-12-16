using ePhoneCourseWork.Data.Static;
using ePhoneCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task <IActionResult> BlacklistUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.BlackListed);
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Users", "Account");
        }


        [HttpPost]
        public async Task<IActionResult> RemoveFromBlacklist(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, UserRoles.BlackListed);
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Users", "Account");
        }
    }
}
