using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        //Get userId for authenticated user
        public static int UserId(this ControllerBase controller)
        {
            var userId = Convert.ToInt32(controller.User.FindFirst("UserId")?.Value);
            return userId;
        }
    }
}
