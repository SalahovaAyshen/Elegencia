﻿using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Repositories
{
    public class PositionRepository:Repository<Position>, IPositionRepository
    {
        public PositionRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
