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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// User Controller Properties
        /// </summary>
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<UserModel> _userManager;

        /// <summary>
        /// UserController Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="user"></param>
        /// <param name="userManager"></param>
        public UserController(ILogger<UserController> logger, UserManager<UserModel> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Controller to get all user using Pagination
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        // GET: api/<UserController> 
        [HttpGet("getalluser")] // {page:int=1}
        public IActionResult GetAllUser(/*int page*/)
        {
            //if (page < 1) return BadRequest("Invalid Page Format");

            // var users = _user.GetAllUser(page);
            var users = _userManager.Users.ToList();

            if (users == null) return BadRequest("Users do not exist");

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

            // if (users.Count() == 0) return Ok("Page does not exists");
            // Return to http response
            return Ok(userReturned);
        }


        /// <summary>
        /// Controller to get the current Logged in User
        /// </summary>
        /// <returns></returns>
        // GET: api/<UserController> 
        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) return BadRequest("User does not exist");

            // Reshape the users details to the DTO model
            var userReturned = new UserReturnedDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Photo = user.Photo,
                DateCreated = user.DateCreated
            };

            // Return to http response
            return Ok(userReturned);
        }

        /// <summary>
        /// Controller to update the current logged in user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // PATCH: api/<UserController> 
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.GetUserAsync(User);

                if (userCheck == null) return NotFound();

                var user = new UserModel
                {
                    FirstName = model.FirstName ?? userCheck.FirstName,
                    LastName = model.LastName ?? userCheck.LastName,
                    Photo = model.Photo ?? userCheck.Photo
                };

                // user.UserName = userCheck.UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role.ToString());

                    return Ok("Updated Successfully");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            ModelState.AddModelError("", "Invalid Credentials");
            return BadRequest(model);
        }

        /// <summary>
        /// Constructor to delete the current logged in user
        /// </summary>
        /// <returns></returns>
        // DELETE: api/<UserController> 
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser()
        {
            var userCheck = await _userManager.GetUserAsync(User);

            if (userCheck == null) return NotFound();

            var user = await _userManager.DeleteAsync(userCheck);

            if (user.Succeeded)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest(user.Errors);
            }
        }
    }
}
