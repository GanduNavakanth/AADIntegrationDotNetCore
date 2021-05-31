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
        public IActionResult UserDetails()
        {
            //var userId= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            // var currentIdentityUser = await UserManager.FindByIdAsync(userId);
            // var roles = await UserManager.GetRolesAsync(currentIdentityUser);
            //user.GetObjectId()
            var claims = User.Claims;
            return View(claims);
        }
        [Authorize(Roles = "AD_POC_ModuleA")]
        public IActionResult ModuleA()
        {
            var claims = User.Claims;
            return View(claims);
        }
        [Authorize(Roles = "AD_POC_ModuleB")]
        public IActionResult ModuleB()
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
        [Authorize(Policy = "AdminModuleAPolicy")]
        public IActionResult ClaimsModuleA()
        {
            var claims = User.Claims;
            return View(claims);
        }
        [Authorize(Policy = "AdminModuleC_Policy")]
        public IActionResult ModuleC_PolicyAuth()
        {
            return Content("Hello from ModuleC_ClaimsAuth Action Method . Sample for RoleBased Authorization using Policy in Authorzation attribute ");
        }
        [Authorize(Policy = "AdminModuleA_ClaimsPolicy")]
        public IActionResult ModuleA_PCAuth()
        {
            return Content("Hello from ModuleA_PCAuth Action Method.ClaimTypes.Role . Sample for Claims Based Authorization using  Policy in Authorzation attribute   ");
        }
        [Authorize(Policy = "AdminModuleC_ClaimsPolicy")]
        public IActionResult ModuleC_PCAuth()
        {
            return Content("Hello from ModuleC_PCAuth Action Method . Sample for Claims Based Authorization using  Policy in Authorzation attribute   ");
        }

        [Authorize(Policy = "AccessToAllAzureAdminGroups")]
        public IActionResult AllAdminAccessModule()
        {
            //Note : This method uses the Custom Authorization Policy thorugh the Authorization Handler .net core concpet
            // In this Hanlder we can  mention multiple conditions to Authorize user. Refer Class -AllAdminsAccessAuthHandler.cs for details

            return Content("This Endpoint uses the Custom Authorization Policy thorugh the Authorization Handler . Users should  belongs to either of AD_POC_Admin or AD_POC_ModuleA or AD_POC_ModuleB or AD_POC_ModuleC Groups");
        }



    }
}
