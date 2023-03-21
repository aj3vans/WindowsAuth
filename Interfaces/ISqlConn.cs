using Microsoft.Data.SqlClient;

namespace WindowsAuth.Interfaces
{
    public interface ISqlConn
    {
        SqlConnection Connect(string connectionString = "DefaultConnection");
    }
}
