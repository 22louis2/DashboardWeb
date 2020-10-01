using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.Models
{
    public class UserModel : IdentityUser
    {

        /// <summary>
        /// UserModel Class Properties
        /// and its Data Annotations
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Max characters allowed is 30")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max characters allowed is 30")]
        public string LastName { get; set; }
        public string Photo { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
