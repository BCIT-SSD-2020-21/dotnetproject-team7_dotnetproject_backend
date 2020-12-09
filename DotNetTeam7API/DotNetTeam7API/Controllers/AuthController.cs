using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DotNetTeam7API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private IConfiguration _config;
        private IServiceProvider _serviceProvider;

        public AuthController(SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IConfiguration config,
        IServiceProvider serviceProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _serviceProvider = serviceProvider;
        }
    }
}
