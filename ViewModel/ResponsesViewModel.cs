using DashboardWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.DTOs
{
    public class ResponsesViewModel
    {
        public ResponsesViewModel()
        {
            AllUsers = new List <UserReturnedDTO> ();
        }
        public bool IsAdmin { get; set; } 
        public string Message { get; set; }
        public List<UserReturnedDTO> AllUsers { get; set; }
    }
}
