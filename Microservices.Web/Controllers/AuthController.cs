﻿using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Microservices.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;
        public AuthController( IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider; 
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO model)
        {
            ResponseDTO responseDTO = await _authService.LoginAsync(model);
           
            if (responseDTO != null && responseDTO.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO =
                    JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(responseDTO.Result));

                await SignInUser(loginResponseDTO);
                _tokenProvider.SetToken(loginResponseDTO.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ModelState.AddModelError("CustomError", responseDTO.Message);
                TempData["error"] = responseDTO.Message;
                
                return View(model);
            }
                        
        }


        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>() 
            {
                new SelectListItem(){Text = SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem(){Text = SD.RoleCustomer,Value=SD.RoleCustomer}
            };   
            ViewBag.RoleList = roleList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO model)
        {
            ResponseDTO result = await _authService.ResgisterAsync(model);
            ResponseDTO assignRole;
            if ( result!= null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(model.Role))
                {
                    model.Role = SD.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(model);
                if (assignRole!=null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Inscrição feita com sucesso!";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem(){Text = SD.RoleCustomer,Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index","Home");
        }

        private async Task SignInUser(LoginResponseDTO model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.Token);
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, 
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        } 


    }
}
