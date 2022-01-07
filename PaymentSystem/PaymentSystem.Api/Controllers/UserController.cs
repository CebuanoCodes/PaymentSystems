using System.Threading.Tasks;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Core.Models;
using PaymentSystem.Core.Services;

namespace PaymentSystem
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMapper _mapper;
        private ILoggerManager _logger;


        public UserController(IUserService userService, IMapper mapper, ILoggerManager logger)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._logger = logger;

        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            //this will be save in the log folder of the registered path in the nlog.config file
             _logger.LogInfo($"Returned user with id: {id}");

            //declaring a variable
            var user = await _userService.GetUserById(id);

            //this will return the user with the parameter inputted with the Status response.
            return Ok(user);
                        
        }
      
    }
}
