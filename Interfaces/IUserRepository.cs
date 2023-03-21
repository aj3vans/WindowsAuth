using WindowsAuth.Models;

namespace WindowsAuth.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetById(int id);

        User GetBysAMAccountName(string sAMAccountName);
    }
}
