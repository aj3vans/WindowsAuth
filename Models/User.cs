namespace WindowsAuth.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string? sAMAccountName  { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfBirth  { get; set; }
    }
}
