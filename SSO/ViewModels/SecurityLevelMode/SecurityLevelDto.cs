﻿using SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class SecurityLevelDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public void SaveTo(SecurityLevel obj)
        {
            this.Id = obj.Id;
            this.Title = obj.Title;
        }
    }
}
