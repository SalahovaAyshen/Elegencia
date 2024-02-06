﻿using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class PaginationVM<T> where T : class, new()
    {
        public double TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public IQueryable<T> Items { get; set; }

    }
}
