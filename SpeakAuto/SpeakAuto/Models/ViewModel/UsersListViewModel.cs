﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAuto.Models.ViewModel
{
    public class UsersListViewModel
    {
        public List<ApplicationUser> ApplicationUsersList { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
