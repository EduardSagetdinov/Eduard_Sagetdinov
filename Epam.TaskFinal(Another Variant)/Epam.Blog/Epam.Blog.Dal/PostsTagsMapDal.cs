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
    public class PostsTagsMapDal : IPostsTagsMapDal
    {
        private string connectionString;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PostsTagsMapDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public IEnumerable<PostsTagsMap> GetPostsTagsMap()
        {
            var result = new List<PostsTagsMap>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetAllPostTagsMap]";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new PostsTagsMap
                        {
                            Id = (int)reader["Id"],
                            PostId = (int)reader["PostId"],
                            TagId = (int)reader["TagId"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public void NewPostsTagsMap(int postId, int tagId)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[NewPostsTagsMap]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterPostId = new SqlParameter("@postId", postId);
                command.Parameters.Add(parameterPostId);
                SqlParameter parameterTagId = new SqlParameter("@tagId", tagId);
                command.Parameters.Add(parameterTagId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void DeletePostsTagsMapByPostId(int postId)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeletePostsTagsMapByPostId]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterPostId = new SqlParameter("@postId", postId);
                command.Parameters.Add(parameterPostId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

    }
}