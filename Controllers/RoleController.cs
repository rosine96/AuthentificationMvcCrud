using AuthMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthMvc.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        
        private RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;  
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
    }
}
