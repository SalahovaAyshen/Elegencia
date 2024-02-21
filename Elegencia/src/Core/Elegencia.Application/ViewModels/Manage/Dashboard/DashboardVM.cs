﻿using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class DashboardVM
    {
        public int UserCount { get; set; }
        public int MessageCount { get; set; }
        public IQueryable<Contact> Contacts { get; set; }
    }
}
