using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;
using Tuesday.Services;

namespace Tuesday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UsersController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        [Route("{idUser}")]
        public UserEntity FindOne(int idUser)
        {
            UrlConfig config = new UrlConfig() { IdUser = idUser };
            return _UserService.FindOne(config);
        }

        [HttpGet]
        public List<UserEntity> FindAll()
        {
            UrlConfig config = new UrlConfig();
            return _UserService.FindAll(config);
        }
    }
}
