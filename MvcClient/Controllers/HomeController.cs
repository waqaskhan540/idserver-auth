﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;

namespace MVC_Client.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["access_token"] = await AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "access_token");
            ViewData["id_token"] = await AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "id_token");


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize]
        public IActionResult UserInfo()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
