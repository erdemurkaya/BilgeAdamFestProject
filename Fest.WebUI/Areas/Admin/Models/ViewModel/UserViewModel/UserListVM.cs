﻿namespace Fest.WebUI.Areas.Admin.Models.ViewModel.UserViewModel
{
    public class UserListVM
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

    }
}
