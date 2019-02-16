using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class UserAdminSqlDao : IUserAdminFakeDao
    {
        public UserAdminSqlDao()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["UserAwardsDb"].ConnectionString;
        }

        protected string _connectionString { get; set; }

        public void AddUserAdmin(UserAdmin userAdmin)
        {
            using (var sqlConnection = new SqlConnection(this._connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddUserAdmin]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterlogin = new SqlParameter("@login", userAdmin.Login);
                command.Parameters.Add(parameterlogin);
                SqlParameter parameterpass = new SqlParameter("@pass", userAdmin.Pass);
                command.Parameters.Add(parameterpass);
                SqlParameter parameteradminOrUser = new SqlParameter("@adminOrUser", userAdmin.AdminOrUser);
                command.Parameters.Add(parameteradminOrUser);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUserAdmin(string login)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this._connectionString))
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
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["UserAwardsDb"].ConnectionString;
            var result = new List<UserAdmin>();
            using (var sqlConnection = new SqlConnection(constr))
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
                            Login = (string)reader["login"],
                            AdminOrUser = (int)reader["adminOrUser"],
                            Pass = (string)reader["pass"],
                        });
                }
            }

            return result;
        }

        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdateUserAdmin]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterlogin = new SqlParameter("@login", userAdmin.Login);
                command.Parameters.Add(parameterlogin);
                SqlParameter parameterpass = new SqlParameter("@pass", userAdmin.Pass);
                command.Parameters.Add(parameterpass);
                SqlParameter parameteradminOrUser = new SqlParameter("@adminOrUser", userAdmin.AdminOrUser);
                command.Parameters.Add(parameteradminOrUser);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
