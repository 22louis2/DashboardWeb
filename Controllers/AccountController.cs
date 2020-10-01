using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DashboardWeb.Controllers.API;
using DashboardWeb.DTOs;
using DashboardWeb.Models;
using DashboardWeb.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Newtonsoft.Json;

namespace DashboardWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<UserModel> _userManager;
        private readonly string apiBaseUrl;
        public AccountController(ILogger<AccountController> logger,
            IWebHostEnvironment hostEnvironment, IConfiguration configuration, UserManager<UserModel> userManager)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Customer")]
        [HttpGet("Profile")]
        public ActionResult Profile(ProfileViewModel model)
        {
            var user = new ProfileViewModel
            {
                Response = model.Response
            };

            return View(user);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpGet("Dashboard")]
        public ActionResult Dashboard(ProfileViewModel model)
        {
            var user = new ProfileViewModel
            {
                Response = model.Response
            };
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            using HttpClient client = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            string endpoint = apiBaseUrl + "/auth/login";
            using var Response = await client.PostAsync(endpoint, content);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var customerJsonString = await Response.Content.ReadAsStringAsync();
                // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                var deserialized = JsonConvert.DeserializeObject<ResponsesViewModel>(custome‌​rJsonString);
                if (deserialized == null) return View();

                var user = new ProfileViewModel
                {
                    Response = deserialized
                };
                //if(deserialized.IsAdmin)
                //{
                //    return View("Dashboard", user);
                //}

                return View("Dashboard", user);//RedirectToAction("Dashboard", "Account", deserialized); //View("Dashboard", user);            
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");
                return View();
            }
        }

        private string UploadedFile(RegisterViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpPost()]
        public IActionResult Logout()
        {
            ViewBag.Message = "Log out successful!";
            AuthController.isLoggedIn = false;
            return View("Login");
        }

        [HttpGet()]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost()]
        public async Task<IActionResult> Signup(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                var user = new UserReturnedViewModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Photo = uniqueFileName,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword
                };

                using HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/auth/register";

                using var Response = await client.PostAsync(endpoint, content);

                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //TempData["Profile"] = JsonConvert.SerializeObject(user);
                    return RedirectToAction("", "Account");
                }
                else if (Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("Username", "Username Already Exist");
                    return View();
                }
                else
                {
                    return View();
                }
            }
            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
