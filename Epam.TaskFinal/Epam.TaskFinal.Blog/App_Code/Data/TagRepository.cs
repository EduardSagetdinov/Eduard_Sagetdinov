using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Epam.TaskFinal.Blog.App_Code.Data
{
    public class TagRepository
    {
        private static readonly string _connectionString = "DefaultConnection";
        public TagRepository()
        {

        }

        public static dynamic Get(int id)
        {
            using (var db = Database.Open(_connectionString))
            {
                var sql = "SELECT * FROM Tag WHERE Id = @0";
                return db.QuerySingle(sql, id);
            }
        }

        public static dynamic Get(string friendlyName)
        {
            using (var db = Database.Open(_connectionString))
            {
                var sql = "SELECT * FROM Tag WHERE UrlFriendlyName = @0";
                return db.QuerySingle(sql, friendlyName);
            }
        }

        public static IEnumerable<dynamic> GetAll(string orderBy = null, string where = null)
        {
            using (var db = Database.Open(_connectionString))
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
                return db.Query(sql);
            }
        }

        public static void Add(string name, string friendlyName)
        {
            using (var db = Database.Open(_connectionString))
            {
                var sql = "INSERT INTO Tag (Name, UrlFriendlyName) " +
                    "VALUES (@0, @1)";
                db.Execute(sql, name, friendlyName);
            }
        }

        public static void Edit(int id, string name, string friendlyName)
        {
            using (var db = Database.Open(_connectionString))
            {
                var sql = "UPDATE Tag SET Name = @0, UrlFriendlyName = @1 " +
                    "WHERE Id = @2";
                db.Execute(sql, name, friendlyName, id);
            }
        }

        public static void Remove(string friendlyName)
        {
            using (var db = Database.Open(_connectionString))
            {
                var sql = "DELETE FROM Tag WHERE UrlFriendlyName = @0";
                db.Execute(sql, friendlyName);
            }
        }
    }
}