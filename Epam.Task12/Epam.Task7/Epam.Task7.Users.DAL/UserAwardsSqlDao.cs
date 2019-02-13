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
    public class UserAwardsSqlDao : IUserAwardsDao
    {
        private string _connectionString;
        public UserAwardsSqlDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public void AddUserAward(UsersAwards userAward)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[AddUserAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterIdUser = new SqlParameter("@IdUser", userAward.IdUser);
                command.Parameters.Add(parameterIdUser);
                SqlParameter parameterIdAward = new SqlParameter("@IdAward", userAward.IdAward);
                command.Parameters.Add(parameterIdAward);
                
                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void DelUserAward(int idUser, int idAward)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[DelUserAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterIdUser = new SqlParameter("@IdUser", idUser);
                command.Parameters.Add(parameterIdUser);
                SqlParameter parameterIdAward = new SqlParameter("@IdAward", idAward);
                command.Parameters.Add(parameterIdAward);

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<UsersAwards> GetAllUserAward()
        {
            var result = new List<UsersAwards>();
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[GetAllUserAward]";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new UsersAwards
                        {
                            IdUser = (int)reader["IdUser"],
                            IdAward = (int)reader["IdAward"],
                        }
                        );
                }
            }
            return result;
        }

        public bool UpdUserAward(UsersAwards userAward)
        {
            using (IDbConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "[UpdUserAward]";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterIdUser = new SqlParameter("@IdUser", userAward.IdUser);
                command.Parameters.Add(parameterIdUser);
                SqlParameter parameterIdAward = new SqlParameter("@IdAward", userAward.IdAward);
                command.Parameters.Add(parameterIdAward);
                
                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }
    }
}
