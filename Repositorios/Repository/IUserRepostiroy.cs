using Login.Models;

namespace Login.Repositorios.Repository
{
    public interface IUserRepostiroy
    {

        Task<string> Register(UserDto userDto, string password);
        Task<string> Login(string email, string passord);
        Task<bool> UserExiste(string email);
    }
}
