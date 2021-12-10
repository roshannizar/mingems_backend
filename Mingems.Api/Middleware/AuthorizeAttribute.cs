using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mingems.Core.Models;
using System;

namespace Mingems.Api.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string Role { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                var ExactRole = Role?.Split(",");
                if (Role != null)
                {
                    if (user.Role.ToString() != ExactRole[0])
                        context.Result = new JsonResult(new { message = "Access Denied" }) { StatusCode = StatusCodes.Status403Forbidden };
                }
                else if (!user.Verify)
                {
                    context.Result = new JsonResult(new { message = "Please verify your account" }) { StatusCode = StatusCodes.Status403Forbidden };
                }
            }
        }
    }
}
