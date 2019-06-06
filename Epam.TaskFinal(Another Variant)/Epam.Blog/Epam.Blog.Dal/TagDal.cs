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
    public class TagDal : ITagDal
    {
        private string connectionString;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public TagDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public IEnumerable<Tag> SelectAllFromTagById(int id)
        {
            var result = new List<Tag>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[SelectAllFromTagById]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Tag
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            UrlFriendlyName = (string)reader["UrlFriendlyName"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public IEnumerable<Tag> SelectAllFromTagByUrlFriendlyName(string urlFriendlyName)
        {
            var result = new List<Tag>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[SelectAllFromTagByUrlFriendlyName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUrlFriendlyName = new SqlParameter("@urlFriendlyName", urlFriendlyName);
                command.Parameters.Add(parameterUrlFriendlyName);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Tag
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            UrlFriendlyName = (string)reader["UrlFriendlyName"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");

                return result;
            }

        }

        public IEnumerable<Tag> GetAllTags(string orderBy = null, string where = null)
        {
            var result = new List<Tag>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();

            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var sql = "SELECT * FROM Tag";

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
                        new Tag
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            UrlFriendlyName = (string)reader["UrlFriendlyName"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result ?? null;
            }
        }

        public void NewTag(string name, string friendlyName)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[NewTag]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@name", name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterUrlFriendlyName = new SqlParameter("@urlFriendlyName", friendlyName);
                command.Parameters.Add(parameterUrlFriendlyName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void UpdateTag(int id, string name, string friendlyName)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdateTag]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterName = new SqlParameter("@name", name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterUrlFriendlyName = new SqlParameter("@urlFriendlyName", friendlyName);
                command.Parameters.Add(parameterUrlFriendlyName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }

        }

        public void DeleteTagByUrlFriendlyName(string urlFriendlyName)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeleteTagByUrlFriendlyName]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUrlFriendlyName = new SqlParameter("@urlFriendlyName", urlFriendlyName);
                command.Parameters.Add(parameterUrlFriendlyName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }
    }
}