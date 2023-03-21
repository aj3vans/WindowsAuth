using WindowsAuth.Models;

namespace WindowsAuth.Interfaces
{
    public interface IUserPermissionRepository
    {
        List<UserPermission> GetById(int userId);

        List<UserPermission> GetBysAMAccountName(string sAMAccountName);
    }
}
