using System.Threading.Tasks;
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

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<User>> GetUserById(int id)
        {

            var user = await _userService.GetUserById(id);

            return Ok(user);
        }

    }
}