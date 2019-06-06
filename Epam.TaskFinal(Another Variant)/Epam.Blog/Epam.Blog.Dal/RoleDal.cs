using Epam.Blog.Dal.Interface;
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
    public class RoleDal : IRoleDal
    {
        private string connectionString;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public RoleDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public IEnumerable<Role> GetRoleById(int id)
        {
            var result = new List<Role>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetRoleById]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Role
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public IEnumerable<string> GetRoleName(int id)
        {
            var result = new List<string>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetRoleName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["Name"]);
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public IEnumerable<Role> GetRoleByName(string name)
        {
            var result = new List<Role>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetRoleByName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@name", name);
                command.Parameters.Add(parameterName);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Role
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public IEnumerable<Role> GetRolesForUser(int id)
        {
            var result = new List<Role>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetRolesForUser]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Role
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }


        public IEnumerable<Role> GetAllRole()
        {
            var result = new List<Role>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetAllRole]";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Role
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public void AddNewRole(string name)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddNewRole]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@name", name);
                command.Parameters.Add(parameterName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void UpdateRole(int id, string name)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdateRole]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@name", name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }

        }

        public void DeleteRoleById(int id)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                logger.Trace("Connecting to DB...");
                var t = Stopwatch.StartNew();
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteRoleById]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void DeleteRoleByName(string name)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteRoleByName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@name", name);
                command.Parameters.Add(parameterName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }
    }
}