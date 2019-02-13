using Epam.Task7.Users.DAL.Interface;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.DAL
{
    public class AwardsSqlDao : IAwardsDao
    {
        private string _connectionString;
        public AwardsSqlDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public void AddAward(Awards award)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterTitle = new SqlParameter("@Title", award.Title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterphotoLink = new SqlParameter("@photoLink", award.photoLink);
                command.Parameters.Add(parameterphotoLink);
               
                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void DelAward(int id)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
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
            var result = new List<Awards> ();
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
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
                            photoLink = (string)reader["photoLink"],
                        }
                        );
                }
            }
            return result;
        }

        public bool UpdAward(Awards award)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@id", award.Id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterTitle = new SqlParameter("@Title", award.Title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterphotoLink = new SqlParameter("@photoLink", award.photoLink);
                command.Parameters.Add(parameterphotoLink);

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }
    }
}
