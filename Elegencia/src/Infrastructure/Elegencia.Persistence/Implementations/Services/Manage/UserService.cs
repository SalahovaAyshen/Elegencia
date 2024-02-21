using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _service;

        public UserService(IHttpContextAccessor http, IAccountService service)
        {
            _http = http;
            _service = service;
        }
        public async Task<AppUser> Get()
        {
            AppUser user = await _service.GetUser(_http.HttpContext.User.Identity.Name);
           
            return user;
        }
    }
}
