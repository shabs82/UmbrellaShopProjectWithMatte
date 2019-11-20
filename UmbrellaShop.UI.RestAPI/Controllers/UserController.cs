﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.Entity;
using UmbrellaShop.Core.Helper;

namespace UmbrellaShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IUserService _userService;
            private IAuthenticationHelper _authenticationHelper;

            public UserController(IUserService userService, IAuthenticationHelper authenticationHelper)
            {
                _userService = userService;
                _authenticationHelper = authenticationHelper;
            }

            // POST api/users -- LOG IN
            [HttpPost]
            public ActionResult Login([FromBody] LoginInputModel loginInputModel)
            {
                try
                {
                    User user = _userService.ValidateUser(loginInputModel);
                    string token = _authenticationHelper.GenerateToken(user);
                    return Ok(new { user.Username, user.IsAdmin, token });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
