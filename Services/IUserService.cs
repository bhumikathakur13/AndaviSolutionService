using AndaviSolutionService.Models;

namespace AndaviSolutionService.Services
{
    public interface IUserService
    {
        string Login(User user);
        int Signup(User user);
    }
}
