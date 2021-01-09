using Valenia.Domain.Shared;
using Valenia.Infrastructure.Application.AutomaticDependencyInjection;

namespace Valenia.Infrastructure.Application
{
    public class PasswordHasher : IPasswordHasher, ISingleton
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
