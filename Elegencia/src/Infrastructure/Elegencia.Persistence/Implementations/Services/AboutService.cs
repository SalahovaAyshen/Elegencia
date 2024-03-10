using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    public class AboutService : IAboutService
    {
        private readonly LayoutService _service;
        private readonly IFamousRepository _famous;

        public AboutService(LayoutService service, IFamousRepository famous)
        {
            _service = service;
            _famous = famous;
        }
        public async Task<AboutVM> GetAll()
        {
            Dictionary<string, string> services = await _service.GetSettingsAsync();
            IQueryable<Famous> famous = _famous.GetAllWithOrder();
            AboutVM aboutVM = new AboutVM
            {
                Services = services,
                Famous = famous
            };
            return aboutVM;
        }
    }
}
