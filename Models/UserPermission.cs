namespace WindowsAuth.Models
{
    public class UserPermission
    {
        public int PermissionId { get; set; }

        public int UserId { get; set; }

        public string? Type { get; set; }

        public string? Name { get; set; }
    }
}
