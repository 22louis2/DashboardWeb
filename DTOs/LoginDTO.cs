using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.DTOs
{
    public class LoginDTO
    {
        /// <summary>
        /// LoginDTO class properties with its
        /// Data annotations
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Max characters allowed is 50")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
