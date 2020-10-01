using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.DTOs
{
    public class EditUserDTO
    {
        /// <summary>
        /// UpdateDTO class model properties
        /// and its Data Annotations
        /// </summary>
        [MaxLength(30, ErrorMessage = "Max characters allowed is 30")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "Max characters allowed is 30")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public string Photo { get; set; }
    }
}
