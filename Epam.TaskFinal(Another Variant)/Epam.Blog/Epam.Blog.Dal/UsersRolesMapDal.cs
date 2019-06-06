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
    public class UsersRolesMapDal : IUsersRolesMapDal
    {
        private string connectionString;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UsersRolesMapDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public IEnumerable<UsersRolesMap> GetAllUsersRole()
        {
            var result = new List<UsersRolesMap>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetAllUsersRole]";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new UsersRolesMap
                        {
                            Id = (int)reader["Id"],
                            UserId = (int)reader["Id"],
                            RoleId = (int)reader["Id"],

                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }
        public void NewUsersRolesMap(int userId, int roleId)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[NewUsersRolesMap]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserId = new SqlParameter("@userId", userId);
                command.Parameters.Add(parameterUserId);
                SqlParameter parameterRoleId = new SqlParameter("@roleId", roleId);
                command.Parameters.Add(parameterRoleId);
                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");

            }
        }

        public void DeleteUsersRolesMap(int userId)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteUsersRolesMapByUserId]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserId = new SqlParameter("@userId", userId);
                command.Parameters.Add(parameterUserId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void DeleteUsersRolesMapByRoleId(int roleId)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteUsersRolesMapByRoleId]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterRoleId = new SqlParameter("@roleId", roleId);
                command.Parameters.Add(parameterRoleId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }
    }
}