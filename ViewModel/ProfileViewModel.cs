using DashboardWeb.DTOs;
using DashboardWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.ViewModel
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            Response = new ResponsesViewModel();

        }
        public ResponseViewModel SingleResponse { get; set; }
        public ResponsesViewModel Response { get; set; }
        public UserEditModel UserViewDetails { get; set; }
        public RegisterViewModel AddUserRegister { get; set; }
        public AddPhotoViewModel AddPhoto { get; set; }
    }
}
