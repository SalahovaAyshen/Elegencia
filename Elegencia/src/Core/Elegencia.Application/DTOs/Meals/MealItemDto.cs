using Elegencia.Application.DTOs.Categories;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.DTOs.Meals
{
    public record MealItemDto(int Id, string Name, decimal Price, string Category);
  
}
