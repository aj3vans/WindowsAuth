using Microsoft.Data.SqlClient;
using System.Data;
using WindowsAuth.Interfaces;
using WindowsAuth.Models;

namespace WindowsAuth.Repositories
{
    public class UserPermissionRepository : IUserPermissionRepository
    {
        private readonly ISqlConn _conn;

        public UserPermissionRepository(ISqlConn conn)
        {
            _conn = conn;
        }
        //--

        public List<UserPermission> GetById(int userId)
        {
            var command = new SqlCommand("UserPermission-GetById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("userId", userId);

            return GetUserPermissions(command);
        }

        public List<UserPermission> GetBysAMAccountName(string sAMAccountName)
        {
            var command = new SqlCommand("UserPermission-GetBysAMAccountName");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("sAMAccountName", sAMAccountName);

            return GetUserPermissions(command);
        }

        private List<UserPermission> GetUserPermissions(SqlCommand command)
        {
            var userPermissions = new List<UserPermission>();

            using (var conn = _conn.Connect())
            {
                command.Connection = conn;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        userPermissions.Add(new UserPermission()
                        {
                            PermissionId = reader.GetInt32("PermissionId"),
                            UserId = reader.GetInt32("UserId"),
                            Type = reader.GetString("Type"),
                            Name = reader.GetString("Name"),
                        });
                    }   

                }
            }
            return userPermissions;
        }
    }
}
