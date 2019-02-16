using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class UserSqlDao : IUserDao
    {
        private string connectionString;

        public UserSqlDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["UserAwardsDb"].ConnectionString;
        }

        public void AddUser(User user)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddUser]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterName = new SqlParameter("@Name", user.Name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterDate = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                command.Parameters.Add(parameterDate);
                SqlParameter parameterLink = new SqlParameter("@photoUserLink", user.PhotoUserLink);
                command.Parameters.Add(parameterLink);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int id)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteUser]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AllUsers";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new User
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["UserName"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            PhotoUserLink = (string)reader["PhotoUserLink"],
                        });
                }
            }

            return result;
        }

        public bool UpdateUser(User user)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdateUser]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter("@id", user.Id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterName = new SqlParameter("@Name", user.Name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterDateOfBirth = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                command.Parameters.Add(parameterDateOfBirth);
                SqlParameter parameterphotoUserLink = new SqlParameter("@photoUserLink", user.PhotoUserLink);
                command.Parameters.Add(parameterphotoUserLink);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
