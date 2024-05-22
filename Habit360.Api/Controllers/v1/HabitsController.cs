using Habit360.Api.DTOs;
using Habit360.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Habit360.Domain.Models;
using Habit360.Domain.Notifications;

namespace Habit360.Api.Controllers.v1
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

            var habit = new Habit(input.Name, input.Description, input.HabitType, input.StartDate, input.Frequency);

            await _habitService.Create(habit);

            return CustomResponse(habit);
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

            var habit = await _habitRepository.ReadById(id);
            if(habit == null) return NotFound(habit);

            habit.UpdateHabit(input.Name, input.Description, input.HabitType, input.StartDate, input.Frequency);

            await _habitService.Update(habit);

            return CustomResponse(input);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            _habitService.Delete(id);
        }
    }
}
