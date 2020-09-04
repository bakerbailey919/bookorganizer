using System;
using System.Data.SqlClient;
using BookServer.Models;
using BookServer.Security;
using BookServer.Security.Models;

namespace BookServer.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        private string sqlGetUser = "SELECT readerId, firstName, lastName, username, password_hash, salt FROM reader WHERE username = @username";
        private string sqlAddUser = "INSERT INTO reader (firstName, lastName, username, password_hash, salt) VALUES " +
            "(@firstName, @lastName, @username, @password_hash, @salt)";

        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    returnUser = GetUserFromReader(reader);
                }
            }

            return returnUser;
        }

        public User AddUser(string username, string password)
        {
            return null;
        }


        public User AddUser(int readerId, string firstName, string lastName, string username, string password)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddUser, conn);
                cmd.Parameters.AddWithValue("@readerId", readerId);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                cmd.Parameters.AddWithValue("@salt", hash.Salt);
                cmd.ExecuteNonQuery();
            }

            return GetUser(username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["readerId"]),
                FirstName = Convert.ToString(reader["firstName"]),
                LastName = Convert.ToString(reader["lastName"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
            };

            return u;
        }
    }
}
