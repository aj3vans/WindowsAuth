using WindowsAuth.Models;

namespace WindowsAuth.ViewModels
{
    public class PermissionManageVm
    {
        public User? User { get; set; }

        public List<UserPermission>? UserPermissions { get; set; }
    }
}
