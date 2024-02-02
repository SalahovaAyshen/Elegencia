using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Elegencia.Persistence.Implementations.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        public MealRepository(AppDbContext context):base(context) { }
        
      
    }
}
