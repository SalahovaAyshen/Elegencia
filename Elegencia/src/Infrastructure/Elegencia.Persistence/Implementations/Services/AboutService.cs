using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
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

        public AboutService(LayoutService service)
        {
            _service = service;
        }
        public async Task<AboutVM> GetAll()
        {
            Dictionary<string, string> services = await _service.GetSettingsAsync();
            AboutVM aboutVM = new AboutVM
            {
                Services = services
            };
            return aboutVM;
        }
    }
}
