using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Epam.Blog.Dal
{
    public class UserDal
    {
        private string connectionString;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UserDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public IEnumerable<Users> SelectAllUsersById(int id)
        {
            var result = new List<Users>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[SelectAllUsersById]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Users
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"],
                            Email = (string)reader["Email"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }
        public IEnumerable<Users> SelectAllUsersByUserName(string userName)
        {
            var result = new List<Users>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[SelectAllUsersByUserName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameteruserName = new SqlParameter("@userName", userName);
                command.Parameters.Add(parameteruserName);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Users
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"],
                            Email = (string)reader["Email"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public IEnumerable<Users> GetAllUsers(string orderBy = null, string where = null)
        {
            var result = new List<Users>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var sql = "SELECT * FROM Users";

                if (!string.IsNullOrEmpty(where))
                {
                    sql += " WHERE " + where;
                }

                if (!string.IsNullOrEmpty(orderBy))
                {
                    sql += " ORDER BY " + orderBy;
                }

                var command = sqlConnection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Users
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"],
                            Email = (string)reader["Email"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public void NewUser(Users user)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[NewUser]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserName = new SqlParameter("@userName", user.UserName);
                command.Parameters.Add(parameterUserName);
                SqlParameter parameterPassword = new SqlParameter("@password", user.Password);
                command.Parameters.Add(parameterPassword);
                SqlParameter parameterEmail = new SqlParameter("@email", user.Email);
                command.Parameters.Add(parameterEmail);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void UpdateUser(int id, string username, string password, string email)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdateUser]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterUserName = new SqlParameter("@userName", username);
                command.Parameters.Add(parameterUserName);
                SqlParameter parameterPassword = new SqlParameter("@password", password);
                command.Parameters.Add(parameterPassword);
                SqlParameter parameterEmail = new SqlParameter("@email", email);
                command.Parameters.Add(parameterEmail);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }

        }

        public void DeleteUserByUserName(string username)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteUserByUserName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserName = new SqlParameter("@username", username);
                command.Parameters.Add(parameterUserName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }
    }
}