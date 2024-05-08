using Habit360.DTOs;
using Habit360.Services;
using Microsoft.AspNetCore.Mvc;

namespace Habit360.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class HabitsController(IHabitService habitService) : ControllerBase
    {
        private readonly IHabitService _habitService = habitService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateHabitDto input)
        {
            return Ok(await _habitService.Create(input));
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _habitService.Read());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHabitDto input)
        {
            return Ok(await _habitService.Update(input));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _habitService.Delete(id);
        }
    }
}
