using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class SettingsGetway
    {

        static Connection con = new Connection();
        private string connectionString = con.GetConnection();
        public int UpdateSeekerPassword(Settings settings)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE JobSeekersInfo SET Password = (@password) where Email = (@email)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = settings.Password;

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = settings.Email;
            

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }
        public bool IsSeekerEmail(Settings settings)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from JobSeekersInfo where Email =(@email)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = settings.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UpdateEmployerPassword(Settings settings)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE EmployersInfo SET Password = (@password) where ContactPersonEmail = (@contactPersonEmail)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = settings.Password;

            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = settings.Email;


            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }
        public bool IsEmployerEmail(Settings settings)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from EmployersInfo where ContactPersonEmail = (@contactPersonEmail)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = settings.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}