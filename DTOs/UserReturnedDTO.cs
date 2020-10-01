using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.DTOs
{
    public class UserReturnedDTO
    {
        /// <summary>
        /// UserReturnedDTO class model properties
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
