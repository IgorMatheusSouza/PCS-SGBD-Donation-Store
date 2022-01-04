﻿using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController 
    {
        private readonly IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService) : base(userService)
        {
            AuthenticationService = authenticationService;
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command) 
        {
            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            var response = await AuthenticationService.RegisterUser(command);
            SaveUserSession(response);

            return OkCreated(response);
        }

        [HttpPost]
        [Route("users/login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if (!command.Validate())
                return ReturnError(command.StatusCode, command.Message);

            var response = await AuthenticationService.Login(command);
            SaveUserSession(response);

            return OkCreated(response);
        }

        [HttpPost]
        [AuthorizationFilter]
        [Route("users/logout")]
        public async Task<IActionResult> Logout()
        {
            var userSession = await GetUserSession();
            await AuthenticationService.Logout(userSession);
            EndUserSession();

            return Ok();
        }
    }
}
