using ePhoneCourseWork.Data;
using ePhoneCourseWork.Data.Static;
using ePhoneCourseWork.Data.ViewModels;
using ePhoneCourseWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Users()
        {
            var users = _context.Users
        .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (user, userRole) => new { User = user, UserRole = userRole })
        .ToList() // Материализовать результаты первого Join
        .Join(_context.Roles, ur => ur.UserRole.RoleId, r => r.Id, (userRole, role) => new { userRole.User, RoleName = role.Name })
        .GroupBy(x => new { x.User.Id, x.User.UserName, x.User.Email })
        .Select(g => new UserVM
        {
            UserId = g.Key.Id,
            UserName = g.Key.UserName,
            Email = g.Key.Email,
            Roles = g.Select(x => x.RoleName).ToList()
        })
        .ToList(); // Материализовать окончательный результат


            return View(users);
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var userTask = _userManager.FindByEmailAsync(loginVM.EmailAddress);
            userTask.Wait();
            var user = userTask.Result;
            if (user != null)
            {
                var passwordCheckTask = _userManager.CheckPasswordAsync(user, loginVM.Password);
                passwordCheckTask.Wait();
                var passwordCheck = passwordCheckTask.Result;
                if (passwordCheck)
                {
                    var resultTask = _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    resultTask.Wait();
                    var result = resultTask.Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Products");
                    }
                }
                TempData["Error"] = "Wrong credentials. Try again.";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Try again.";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
                return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}
