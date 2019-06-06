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
using System.Web.WebPages;

namespace Epam.Blog.Dal
{
    public class PostDal : IPostDal
    {
        private string connectionString { get; set; }
        
        public PostDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<Post> GetPublishedPosts()
        {
            var result = new List<Post>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetPublishedPosts]";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Post
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Content = (string)reader["Content"],
                            DateCreated = (DateTime)reader["DateCreated"],
                            DatePublished = (DateTime)reader["DatePublished"],
                            AuthorId = (int)reader["AuthorId"],
                            Slug = (string)reader["Slug"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.ToArray();
            }
        }

        public IEnumerable<Post> PostBySlug(string slug)
        {
            var result = new List<Post>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[PostBySlug]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSlug = new SqlParameter("@slug", slug);
                command.Parameters.Add(parameterSlug);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                var post = new Post();
                while (reader.Read())
                {

                    post.Id = (int)reader["Id"];
                    post.Title = (string)reader["Title"];
                    post.Content = (string)reader["Content"];
                    post.DateCreated = (DateTime)reader["DateCreated"];

                    post.DatePublished = reader["DatePublished"] == DBNull.Value ? null :(DateTime?)reader["DatePublished"];
                    post.AuthorId = (int)reader["AuthorId"];
                    post.Slug = (string)reader["Slug"];
                            
                        result.Add(post);
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result;
            }
        }

        public IEnumerable<forGet> SelectAllUserPublishedPostsAndTags()
        {
            List<forGet> result = new List<forGet>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("[SelectAllUserPublishedPostsAndTags]", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    var reader = dt.CreateDataReader();
                    while (reader.Read())
                    {
                        forGet forg = new forGet();


                        forg.post.Id = (int)reader["Id"];
                        forg.post.Title = (string)reader["Title"];
                        forg.post.DateCreated = (DateTime)reader["DateCreated"];
                        forg.post.DatePublished = (DateTime)reader["DatePublished"];
                        forg.post.AuthorId = (int)reader["AuthorId"];
                        forg.post.Slug = (string)reader["Slug"];

                        forg.tag.Id = (int)reader["Id"];
                        forg.tag.Name = (string)reader["Name"];
                        forg.tag.UrlFriendlyName = (string)reader["UrlFriendlyName"];

                        forg.user.UserName = (string)reader["UserName"];



                        result.Add(forg);

                    }
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.ToArray();
            }
        }


        public IEnumerable<forGet> GetPublishedPostsByTag(string urlFriendlyName)
        {
            var result = new List<forGet>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetPublishedPostsByTag]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterUrlFriendlyName = new SqlParameter("@urlFriendlyName", urlFriendlyName);
                command.Parameters.Add(parameterUrlFriendlyName);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var p = new Post();
                    var tag = new Tag();
                    var u = new Users();
                    var resp = new forGet();
                    p.Id = (int)reader["Id"];
                    p.Title = (string)reader["Title"];
                    p.Content = (string)reader["Content"];
                    p.DateCreated = (DateTime)reader["DateCreated"];
                    p.DatePublished = (DateTime)reader["DatePublished"];
                    p.AuthorId = (int)reader["AuthorId"];
                    p.Slug = (string)reader["Slug"];
                    tag.Id = (int)reader["TagId"];
                    tag.Name = (string)reader["TagName"];
                    tag.UrlFriendlyName = (string)reader["TagUrlFriendlyName"];
                    u.UserName = (string)reader["UserName"];
                    p.tags.Add(tag);
                    resp.post = p;
                    resp.tag = tag;
                    resp.user = u;
                    result.Add(resp);
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.ToArray();
            }
        }

        public IEnumerable<Post> GetPostById(int id)
        {
            var result = new List<Post>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetPostById]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Post
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Content = (string)reader["Content"],
                            DateCreated = (DateTime)reader["DateCreated"],
                            DatePublished = (DateTime)reader["DatePublished"],
                            AuthorId = (int)reader["AuthorId"],
                            Slug = (string)reader["Slug"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.ToArray();
            }
        }

        public forGet Get(int id)
        {
            List<forGet> result = new List<forGet>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            var sql = "SELECT p.*, t.Id as TagId, t.Name as TagName, t.UrlFriendlyName " +
                      "as TagUrlFriendlyName, u.UserName FROM Post p " +
                      "LEFT JOIN PostsTagsMap m ON p.Id = m.PostId " +
                      "LEFT JOIN Tag t ON t.Id = m.TagId " +
                      "INNER JOIN Users u ON u.Id = p.AuthorId WHERE p.Id = @id";
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Post postGet = new Post();
                    Tag tagGet = new Tag();
                    Users userGet = new Users();

                    postGet.Id = (int)reader["Id"];
                    postGet.Title = (string)reader["Title"];
                    postGet.DateCreated = (DateTime)reader["DateCreated"];
                    postGet.DatePublished = reader["DatePublished"] == DBNull.Value ? null : (DateTime?)reader["DatePublished"];
                    postGet.AuthorId = (int)reader["AuthorId"];
                    postGet.Slug = (string)reader["Slug"];

                    tagGet.Id = (int)reader["TagId"];
                    tagGet.Name = (string)reader["TagName"];
                    tagGet.UrlFriendlyName = (string)reader["TagUrlFriendlyName"];

                    userGet.UserName = (string)reader["UserName"];

                    forGet forG = new forGet();
                    forG.post = postGet;
                    forG.tag = tagGet;
                    forG.user = userGet;
                    result.Add(forG);
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.Any() ? result.First() : null;
            }
        }


        public forGet GetPostBySlug(string slug)
        {
            var result = new List<forGet>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetPostBySlug]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterSlug = new SqlParameter("@slug", slug);
                command.Parameters.Add(parameterSlug);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Post postGet = new Post();
                    Tag tagGet = new Tag();
                    Users userGet = new Users();
                    postGet.tags = new List<Tag>();
                    postGet.Id = (int)reader["Id"];
                    postGet.Title = (string)reader["Title"];
                    postGet.DateCreated = (DateTime)reader["DateCreated"];
                    postGet.DatePublished = (DateTime?)reader["DatePublished"];
                    postGet.AuthorId = (int)reader["AuthorId"];
                    postGet.Slug = (string)reader["Slug"];
                    tagGet.Id = reader["TagId"] == DBNull.Value ? 0 : (int)reader["TagId"];
                    tagGet.Name = reader["TagName"] == DBNull.Value ? null : (string)reader["TagName"];
                    tagGet.UrlFriendlyName = reader["TagUrlFriendlyName"] == DBNull.Value ? null : (string)reader["TagUrlFriendlyName"];
               
                    postGet.tags.Add(tagGet);
                    userGet.UserName = (string)reader["UserName"];

                    forGet forG = new forGet();
                    forG.post = postGet;
                    forG.tag = tagGet;
                    forG.user = userGet;
                    result.Add(forG);
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.Any() ? result.First() : null;
            }
        }

        public IEnumerable<Post> GetAllPosts()
        {
            var result = new List<Post>();
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetAllPosts]";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Post
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Content = (string)reader["Content"],
                            DateCreated = (DateTime)reader["DateCreated"],
                            DatePublished = (DateTime)reader["DatePublished"],
                            AuthorId = (int)reader["AuthorId"],
                            Slug = (string)reader["Slug"],
                        });
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.ToArray();
            }
        }

        public void NewPost(string title, string content, string slug, DateTime? datePublished = null, int authorId = 0)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[NewPost]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterTitle = new SqlParameter("@title", title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterContent = new SqlParameter("@content", content);
                command.Parameters.Add(parameterContent);
                if (datePublished != null)
                {
                    SqlParameter parameterDatePublished = new SqlParameter("@datePublished", datePublished);
                    command.Parameters.Add(parameterDatePublished);
                }
                
                SqlParameter parameterAuthorId = new SqlParameter("@authorId", authorId);
                command.Parameters.Add(parameterAuthorId);
                SqlParameter parameterSlug = new SqlParameter("@slug", slug);
                command.Parameters.Add(parameterSlug);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

        public void UpdatePost(int id, string title, string content,
           string slug, DateTime? datePublished, int authorId)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(connectionString))
            {
                
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdatePost]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterTitle = new SqlParameter("@title", title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterContent = new SqlParameter("@content", content);
                command.Parameters.Add(parameterContent);
                if (datePublished != null)
                {
                    SqlParameter parameterDatePublished = new SqlParameter("@datePublished", datePublished);
                    command.Parameters.Add(parameterDatePublished);
                }
                else
                {
                    SqlParameter parameterDatePublished = new SqlParameter("@datePublished", DBNull.Value);
                    command.Parameters.Add(parameterDatePublished);
                }
                
                
                SqlParameter parameterAuthorId = new SqlParameter("@authorId", authorId);
                command.Parameters.Add(parameterAuthorId);
                SqlParameter parameterSlug = new SqlParameter("@slug", slug);
                command.Parameters.Add(parameterSlug);
                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }

        }

        public void DeletePost(int id)
        {
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DeletePost]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
            }
        }

            public forGet Get(string slug)
            {
                List<forGet> result = new List<forGet>();
                var sql = "SELECT p.*, t.Id as TagId, t.Name as TagName, " +
                          "t.UrlFriendlyName as TagUrlFriendlyName, u.Username FROM Post p " +
                          "LEFT JOIN PostsTagsMap m ON p.Id = m.PostId " +
                          "LEFT JOIN Tag t ON t.Id = m.TagId " +
                          "INNER JOIN Users u ON u.Id = p.AuthorId WHERE Slug = @slug";
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    SqlParameter parameterSlug = new SqlParameter("@slug", slug);
                    command.Parameters.Add(parameterSlug);
                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    Post postGet = new Post();
                    Tag tagGet = new Tag();
                    Users userGet = new Users();

                    postGet.Id = (int)reader["Id"];
                    postGet.Title = (string)reader["Title"];
                    postGet.DateCreated = (DateTime)reader["DateCreated"];
                    postGet.DatePublished = reader["DatePublished"] == DBNull.Value ? null : (DateTime?)reader["DatePublished"];
                    postGet.AuthorId = (int)reader["AuthorId"];
                    postGet.Slug = (string)reader["Slug"];

                    tagGet.Id = (int)reader["TagId"];
                    tagGet.Name = (string)reader["TagName"];
                    tagGet.UrlFriendlyName = (string)reader["TagUrlFriendlyName"];

                    userGet.UserName = (string)reader["UserName"];

                    forGet forG = new forGet();
                    forG.post = postGet;
                    forG.tag = tagGet;
                    forG.user = userGet;

                    result.Add(forG);

                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.Any() ? result.First() : null;
                }
            }

        public IEnumerable<forGet> GetAll(string orderBy = null)
        {
            List<forGet> result = new List<forGet>();
            var sql = "SELECT p.*, t.Id as TagId, t.[Name] as TagName, t.UrlFriendlyName " +
                      "as TagUrlFriendlyName, u.UserName FROM Post p " +
                      "LEFT JOIN PostsTagsMap m ON p.Id = m.PostId " +
                      "LEFT JOIN Tag t ON t.Id = m.TagId " +
                      "INNER JOIN Users u ON u.Id = p.AuthorId";
            if (!string.IsNullOrEmpty(orderBy))
            {
                sql += " ORDER BY " + orderBy;
            }
            logger.Trace("Connecting to DB...");
            var t = Stopwatch.StartNew();
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Post postGet = new Post();
                    Tag tagGet = new Tag();
                    Users userGet = new Users();

                    postGet.Id = (int)reader["Id"];
                    postGet.Title = (string)reader["Title"];
                    postGet.DateCreated = (DateTime)reader["DateCreated"];
                    postGet.DatePublished = reader["DatePublished"] == DBNull.Value ? null :(DateTime?)reader["DatePublished"];
                    postGet.AuthorId = (int)reader["AuthorId"];
                    postGet.Slug = (string)reader["Slug"];

                    tagGet.Id = (int)reader["Id"];
                    tagGet.Name = (reader["TagName"] != DBNull.Value) ? (string)reader["TagName"] : string.Empty;
                    tagGet.UrlFriendlyName = (reader["TagUrlFriendlyName"] != DBNull.Value) ? (string)reader["TagUrlFriendlyName"] : string.Empty; 

                    userGet.UserName = (string)reader["UserName"];

                    forGet forG = new forGet(); 
                    forG.post = postGet;
                    forG.tag = tagGet;
                    forG.user = userGet;

                    result.Add(forG);
                }
                logger.Trace("Operation successfuly ended throw " + t.ElapsedMilliseconds + "milliseconds");
                return result.ToArray();
            }
        }
    }
}