using AutoMapper;
using HotelListing.Data;
using HotelListing.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper mapper;
        private readonly ILogger<AcountController> logger;

        public AcountController(
            UserManager<ApiUser> userManager, IMapper mapper, ILogger<AcountController> logger
            )
        {
            _userManager = userManager;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Register([FromBody] CreateUserDTO createUser)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Map CreateUser object to APiUser object
            var user = mapper.Map<ApiUser>(createUser);
            // Store User
            user.UserName = createUser.Email;
           var result = await _userManager.CreateAsync(user, createUser.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest( ModelState);
            }

            return Accepted(createUser);
            

        }
    }
}
