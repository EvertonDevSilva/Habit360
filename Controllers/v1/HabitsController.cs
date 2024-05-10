using Habit360.DTOs;
using Habit360.Interfaces;
using Habit360.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Habit360.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitsController(IHabitService habitService,
                                  IHabitRepository habitRepository,
                                  INotificator notificator) : MainController(notificator)
    {
        private readonly IHabitRepository _habitRepository = habitRepository;
        private readonly IHabitService _habitService = habitService;

        [HttpPost]
        public async Task<IActionResult> Create(HabitDto input)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);
            
            
            await _habitService.Create(input);

            return CustomResponse(input);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _habitRepository.Read());
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, HabitDto input)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _habitService.Update(id, input);

            return CustomResponse(input);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            _habitService.Delete(id);
        }
    }
}
