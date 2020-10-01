using DashboardWeb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.ViewModel
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            AllUsers = new UserReturnedDTO();
        }
        public UserReturnedDTO AllUsers { get; set; }
    }
}
