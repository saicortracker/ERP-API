using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ERPContext _appDBContext;
        public LoginController(ERPContext eRPContext)
        {
            _appDBContext = eRPContext;
        }
        [HttpPost]
        [Route("authenticate")]
        public usersDto authenticate(authenticateRequestModel model)
        {
            var user = _appDBContext.Users.Where(a => a.UserName == model.Username && a.Password == model.Password).FirstOrDefault();
            if (user != null)
            {
                return new usersDto
                {
                  userName=user.UserName,
                  password=user.Password,
                  first_name=user.FirstName,
                  last_name=user.LastName,
                  email=user.Email
                };
            }
            return null;
        }

    }
}
