using Microsoft.Data.SqlClient;
using System.Data;
using WindowsAuth.Interfaces;
using WindowsAuth.Models;

namespace WindowsAuth.Repositories
{
    public class UserRepositiory : IUserRepository
    {
        private readonly ISqlConn _conn;

        public UserRepositiory(ISqlConn conn)
        { 
            _conn = conn;
        }
        //--

        public List<User> GetAll()
        {
            var command = new SqlCommand("User-GetAll");
            command.CommandType = CommandType.StoredProcedure;

            return GetUsers(command);
        }

        public User GetById(int userId)
        {
            var command = new SqlCommand("User-GetById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", userId);

            return GetUser(command);
        }

        public User GetBysAMAccountName(string sAMAccountName)
        {
            var command = new SqlCommand("User-GetBysAMAccountName");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sAMAccountName", sAMAccountName);

            return GetUser(command);
        }

        private  List<User> GetUsers(SqlCommand command)
        {
            var users = new List<User>();

            using (var conn = _conn.Connect())
            {
                command.Connection = conn;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User() 
                        { 
                            UserId = reader.GetInt32("UserId"), 
                            sAMAccountName = reader.GetString("sAMAccountName"),  
                            Name = reader.GetString("Name"),
                            DateOfBirth = reader.GetDateTime("DateOfBirth")
                        });
                    }
                }
            }
            return users;
        }

        private User GetUser(SqlCommand command)
        {
            var user = new User();

            using (var conn = _conn.Connect())
            {
                command.Connection = conn;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.UserId = reader.GetInt32("UserId");
                        user.sAMAccountName = reader.GetString("sAMAccountName");
                        user.Name = reader.GetString("Name");
                        user.DateOfBirth = reader.GetDateTime("DateOfBirth");
                    }                   
                }
            }
            return user;
        }

    }
}
