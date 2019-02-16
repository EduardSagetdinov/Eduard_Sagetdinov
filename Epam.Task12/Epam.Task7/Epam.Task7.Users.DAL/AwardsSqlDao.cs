using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.DAL
{
    public class AwardsSqlDao : IAwardsDao
    {
        private string connectionString;

        public AwardsSqlDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["UserAwardsDb"].ConnectionString;
        }

        public void AddAward(Awards award)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterTitle = new SqlParameter("@Title", award.Title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterphotoLink = new SqlParameter("@photoLink", award.PhotoLink);
                command.Parameters.Add(parameterphotoLink);
               
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DelAward(int id)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DelAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Awards> GetAll()
        {
            var result = new List<Awards>();
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();

                command.CommandText = "[GetAllAwards]";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Awards
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            PhotoLink = (string)reader["photoLink"],
                        });
                }
            }

            return result;
        }

        public bool UpdAward(Awards award)
        {
            using (IDbConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", award.Id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterTitle = new SqlParameter("@Title", award.Title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterphotoLink = new SqlParameter("@photoLink", award.PhotoLink);
                command.Parameters.Add(parameterphotoLink);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
