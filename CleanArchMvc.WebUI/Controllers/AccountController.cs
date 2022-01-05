﻿using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;

        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }

        [HttpGet]
        public IActionResult Register() { }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

        }
        [HttpGet]
        public IActionResult Login() { }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) { }

        public async Task<IActionResult> Logout() { }
    }
}
