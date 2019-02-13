using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.DAL
{
    public class UserAdminSqlDao : IUserAdminFakeDao
    {
        private string _connectionString;
        public UserAdminSqlDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public void AddUserAdmin(UserAdmin userAdmin)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddUserAdmin]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterlogin = new SqlParameter("@login", userAdmin.login);
                command.Parameters.Add(parameterlogin);
                SqlParameter parameterpass = new SqlParameter("@pass", userAdmin.pass);
                command.Parameters.Add(parameterpass);
                SqlParameter parameteradminOrUser = new SqlParameter("@adminOrUser", userAdmin.adminOrUser);
                command.Parameters.Add(parameteradminOrUser);


                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void DeleteUserAdmin(string login)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteUserAdmin]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterlogin = new SqlParameter("@login", login);
                command.Parameters.Add(parameterlogin);

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<UserAdmin> GetAll()
        {
            var result = new List<UserAdmin>();
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetAllUserAdmin]";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new UserAdmin
                        {
                            login = (string)reader["login"],
                            adminOrUser = (int)reader["adminOrUser"],
                            pass = (string)reader["pass"],
                        }
                        );
                }
            }
            return result;
        }

        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdateUserAdmin]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterlogin = new SqlParameter("@login", userAdmin.login);
                command.Parameters.Add(parameterlogin);
                SqlParameter parameterpass = new SqlParameter("@pass", userAdmin.pass);
                command.Parameters.Add(parameterpass);
                SqlParameter parameteradminOrUser = new SqlParameter("@adminOrUser", userAdmin.adminOrUser);
                command.Parameters.Add(parameteradminOrUser);
                
                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }
    }
}
