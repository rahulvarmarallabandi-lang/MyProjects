using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyWebApi.Controllers;
using MyWebApi.Model;
using Dapper;



namespace MyWebApi.DataBase

{
    public class EmployeeDAL
    {
        private readonly string _connectionString;
        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [Obsolete]
        public void InsertEmployee(MyModel emp)
        {
            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("InsertEmployee", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Email", emp.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public List<MyModel> GetEmployees(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var result = conn.Query<MyModel>("GetEmployees", new { Id = id },commandType: CommandType.StoredProcedure).ToList();

            return result;
        }
        

        public void RegisterUser(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Username", user.Name);
        
            parameters.Add("@Email", user.email);
            parameters.Add("@Password", user.Password);

            connection.Execute("sp_RegisterUser", parameters, commandType: CommandType.StoredProcedure);
        }
        public void ValidateUserAsync(LoginDto model)
        {

            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", model.UserId);

            parameters.Add("@Password", model.Password);
           
            connection.Execute("sp_LoginUser", parameters, commandType: CommandType.StoredProcedure);

        }


    }


}
