using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SampleAADDotnetCore.CustomAuthorizationPolicies
{
    //This Auhtorization Handler is to Allow the User are in part of set of  ADGroups . In this sample Few AAD groups are assumed as Admin AAD Groups
    //The Azure AD Groups which are considered as Admin Groups are AD_POC_Admin , AD_POC_ModuleA , AD_POC_ModuleB and AD_POC_ModuleC
    public class AllAdminsAccessAuthHandler : AuthorizationHandler<AllAdminsAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllAdminsAccessRequirement requirement)
        {
            //If the user is part of any of the below Groups then he should be able to access the Endpoint
            //AD_POC_Admin or AD_POC_ModuleA or AD_POC_ModuleB or AD_POC_ModuleC

            if (context.User.HasClaim(c => c.Value == "AD_POC_Admin") || context.User.HasClaim(c => c.Value == "AD_POC_ModuleA") 
                || context.User.HasClaim(c => c.Value == "AD_POC_ModuleB") || context.User.HasClaim(c => c.Value == "AD_POC_ModuleC") )

            {
                context.Succeed(requirement);
            }
           return Task.CompletedTask;
        }
    }
}
