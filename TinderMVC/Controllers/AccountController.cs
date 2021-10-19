using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Service.Abstract;
using TinderMVC.Models;

namespace GirisKayit.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWorkPattern _unitOfWork;
        private readonly IUserService _userService;
        public AccountController(IUserService userService, IUnitOfWorkPattern unitOfWork, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, user.Password);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                        ModelState.Clear();
                        return View();
                    }
                }
                await _userService.Add(user);
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {

                User loginUser = (await _userService.GetAll()).FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
                if (loginUser != null)
                {

                    var user = await _userManager.FindByNameAsync(login.UserName);
                    var password = await _userManager.CheckPasswordAsync(user, login.Password);

                    var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            return View(login);
        }

    }
}