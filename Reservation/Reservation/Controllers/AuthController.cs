using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data.DataAccess;
using Reservation.Models;
using System.Diagnostics;
using Reservation.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Reservation.Data;

namespace Reservation.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserDataAccess _userDataAccess; 
        private readonly Validate _validate;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;

        public AuthController(IMapper mapper, UserDataAccess userDataAccess,Validate validate,
            UserManager<User> userManager,
            SignInManager<User> signManager
            )
        {
            _mapper = mapper;
            _userDataAccess = userDataAccess;
            _validate = validate;
            _userManager = userManager;
            _signManager = signManager;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Save(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    var mapper = _mapper.Map<User>(model);
                    // var inserted = _userDataAccess.AddOrUpdateUser(mapper); 
                    //mapper.UserName = model.Email;
                    var result = await _userManager.CreateAsync(mapper, model.Password);
                    if (result.Succeeded)
                    {
                        //var user = _userDataAccess.GetUserDataById(result..NewId);
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        await _signManager.SignInAsync(user, false);
                        // login 
                        //if(_validate.ValidateLogin(model.Email, model.Password))
                        return RedirectToAction("index", "home");
                    }
                    // return to sign up again 
                }
            }
            return View("Register", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
       

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                //var user = _userDataAccess.GetUserDataByEmail(model.Email);
                //if (!user.Password.Equals(model.Password))
                //{
                //    ModelState.AddModelError("Password", "Invalid credentials");
                //    return View(model);

                //}
                //if(_validate.Login(model.Email, model.Password))
                //    return RedirectToAction("index", "home"); 

                var result = await _signManager.PasswordSignInAsync(user.Email, user.Password, true, true);

                if (result.Succeeded)
                {
                    //await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }


    }
}