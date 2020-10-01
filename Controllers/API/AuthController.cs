using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashboardWeb.DTOs;
using DashboardWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DashboardWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Account Controller Properties
        /// </summary>
        private readonly ILogger<AuthController> _logger;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly Helpers.Utility _utility;
        public static UserReturnedDTO userReturned { get; set; }
        public static bool isLoggedIn { get; set; }
        private bool _isAdmin { get; set; } = false;
        public static int adminRole { get; set; }
        public static int customerRole { get; set; }

        /// <summary>
        /// AccountController Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="account"></param>
        public AuthController(ILogger<AuthController> logger, SignInManager<UserModel> signInManager,
            UserManager<UserModel> userManager, Helpers.Utility utility)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _utility = utility;
        }

        /// <summary>
        /// Controller to Register a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // GET: api/<AccountController>/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    Photo = model.Photo
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");

                    return Ok(result);
                }

                //return BadRequest("User cannot be registered. Invalid Credentials");
            }

            ModelState.AddModelError("", "Invalid Credentials");
            return BadRequest(model);
        }

        /// <summary>
        /// Controller to Login User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // GET: api/<AccountController>/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result == null) return Unauthorized();

                var user = await _userManager.FindByEmailAsync(model.Email);

                userReturned = new UserReturnedDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Photo = user.Photo,
                    DateCreated = user.DateCreated
                };
                isLoggedIn = true;

                if (user == null) return BadRequest("Invalid Credentials");

                var token = _utility.JWTHandler(user);

                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return Ok(new ResponsesViewModel
                    {
                        Message = token,
                        IsAdmin = true,
                        AllUsers = GetAllUser().ToList()
                    });
                }
                return Ok(new ResponsesViewModel
                {
                    Message = token,
                    IsAdmin = _isAdmin,
                    AllUsers = new List<UserReturnedDTO>() { new UserReturnedDTO {
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        Email = user.Email,
                        Photo = user.Photo,
                        DateCreated = user.DateCreated
                    } }
                });
            }

            ModelState.AddModelError("", "Invalid Credentials");
            return Unauthorized(model);
        }

        public IEnumerable<UserReturnedDTO> GetAllUser()
        {
            var users = _userManager.Users.ToList();

            if (users == null) return null;

            adminRole = _userManager.GetUsersInRoleAsync("Admin").Result.Count;
            customerRole = _userManager.GetUsersInRoleAsync("Customer").Result.Count;

            List<UserReturnedDTO> userReturned = new List<UserReturnedDTO>();

            // Reshape the users details to the DTO model
            foreach (var item in users)
            {
                userReturned.Add(new UserReturnedDTO
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Photo = item.Photo,
                    DateCreated = item.DateCreated
                });
            }

            return userReturned;
        }

        /// <summary>
        /// Controller to Logout User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // GET: api/<AccountController>/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }

            return BadRequest();
        }
    }
}
