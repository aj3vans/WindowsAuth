using Microsoft.Data.SqlClient;
using WindowsAuth.Interfaces;

namespace WindowsAuth.Connections
{
    public class SqlConn : ISqlConn
    {
        private readonly IConfiguration _config;

        public SqlConn(IConfiguration config)
        {
            _config = config;
        }
        //--

        public SqlConnection Connect(string connectionString = "DefaultConnection")
        {
			try
			{
                var conn = new SqlConnection(_config.GetConnectionString(connectionString));    
                conn.Open();
                return conn;
			}
            catch (SqlException) { throw; }
			catch (Exception) { throw; }
        }
    }

    /*
        Alternatively approach to adding a connection object to a repository. 
        Rather than injecting the object via DI, you can add the object as a static object 
        to pass the open connection.  
    */
    //public class Sql
    //{        
    //    public static SqlConnection Connect(string connectionString = "DefaultConnection")
    //    {
    //        try
    //        {
    //            // get configuration settings 
    //            var configurationBuilder = new ConfigurationBuilder()
    //                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    //            var _configuration = configurationBuilder.Build();

    //            // set connection string 
    //            var connString = _configuration.GetConnectionString(connectionString);
    //            var connection = new SqlConnection(connString);
    //            connection.Open();

    //            return connection;
    //        }
    //        catch (SqlException) { throw; }
    //        catch (Exception) { throw; }
    //    }
    //}
}
