using Habit360.Domain.Interfaces;
using Habit360.Domain.Models;
using Habit360.Domain.Notifications;
using Habit360.Domain.Validations;
using Microsoft.AspNetCore.Identity;

namespace Habit360.Domain.Services
{
    public class UserService(IUserRepository userRepository, INotificator notificator)
        : BaseService(notificator), IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        
        public async Task Create(User user)
        {
            if (!ValidatorExecute(new UserValidator(), user)) return;

            if(_userRepository.Search(u => u.Email == user.Email).Result.Any())
            {
                Notify("Email já cadastrado");
                return;
            }

            user.Password = PasswordHasher(user);
            
            await _userRepository.Create(user);
        }
                
        public async Task Update(User user)
        {
            if (!ValidatorExecute(new UserValidator(), user)) return;
            await _userRepository.Update(user);
        }

        public async Task Delete(int Id)
        {
            await _userRepository.Delete(Id);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        private static string PasswordHasher(User user)
        {
            var password = user.Password;

            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, password);

            return user.Password;
        }
    }
}
