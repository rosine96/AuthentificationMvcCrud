using AuthMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuthMvc.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager; 
            _userManager = userManager;
        }
        [Authorize(Roles = "Administrateur" )]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [Authorize(Roles = "Administrateur")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }
        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
           
             await _roleManager.CreateAsync(role);
             return View();
        }
        public async Task<IActionResult> GetMyRoles()
        {
         var userEmail =User.FindFirstValue(ClaimTypes.Email);
         var user = await _userManager.FindByEmailAsync(userEmail);
            var roles = await _userManager.GetRolesAsync(user);
            return View(roles);
        }
    }
}
