namespace Valenia.Domain.Shared
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
