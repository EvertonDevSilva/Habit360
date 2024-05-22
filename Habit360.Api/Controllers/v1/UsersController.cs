using Habit360.Api.DTOs;
using Habit360.Domain.Interfaces;
using Habit360.Domain.Models;
using Habit360.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Habit360.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController(IUserService userService, IUserRepository userRepository, INotificator notificator) : MainController(notificator)
    {
        private readonly IUserService _userService = userService;
        private readonly IUserRepository _userRepository = userRepository;

        [HttpPost]
        public async Task<IActionResult> Create(UserDto input)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new User(input.Name, input.Email, input.Password);
            
            await _userService.Create(user);

            return CustomResponse(input);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _userRepository.Read());
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, User input)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = await _userRepository.ReadById(id);
            if (user == null) return NotFound();

            user.UpdateUser(input.Name, input.Email, input.Password);

            await _userService.Update(user);

            return CustomResponse(user);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {

        }
    }
}
