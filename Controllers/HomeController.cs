using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SampleAADDotnetCore.Controllers
{
    public class HomeController : Controller
    {
       


        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "AD_POC_Admin")]
        public  IActionResult UserDetails()
        {
            //var userId= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            // var currentIdentityUser = await UserManager.FindByIdAsync(userId);
            // var roles = await UserManager.GetRolesAsync(currentIdentityUser);
            //user.GetObjectId()
            var claims = User.Claims;
            return View(claims);
        }
        [Authorize(Roles = "AD_POC_ModuleA")]
        public  IActionResult ModuleA()
        {
            var claims = User.Claims;
            return View(claims);
        }
        [Authorize(Roles = "AD_POC_ModuleB")]
        public  IActionResult ModuleB()
        {
            var claims = User.Claims;
            return View(claims);
        }
        [Authorize(Roles = "AD_POC_ModuleC")]
        public IActionResult ModuleC()
        {
            var claims = User.Claims;
            return View(claims);
        }
        
        public IActionResult ClaimsModuleA()
        {
            var claims = User.Claims;
            return View(claims);
        }
    }
}
