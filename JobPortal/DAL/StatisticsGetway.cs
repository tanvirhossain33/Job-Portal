using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class StatisticsGetway
    {

        static Connection con = new Connection();
        private string connectionString = con.GetConnection();

        public List<Statistics> GetJobInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT EmployersInfo.CompanyName, JobInfo.JobID, JobInfo.JobTitle, JobInfo.EducationalRequirements, JobInfo.ExperienceRequirements, JobInfo.ApplicationDeadline, COUNT(AppliedJobInfo.JobID) AS TotalApply FROM AppliedJobInfo INNER JOIN JobInfo ON JobInfo.JobID=AppliedJobInfo.JobID INNER JOIN  EmployersInfo ON JobInfo.EmployerID = EmployersInfo.EmployerID and JobInfo.ApplicationDeadline >= (@currentDate) GROUP BY EmployersInfo.CompanyName, JobInfo.JobID, JobInfo.JobTitle, JobInfo.EducationalRequirements, JobInfo.ExperienceRequirements, JobInfo.ApplicationDeadline";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("currentDate", SqlDbType.DateTime);
            command.Parameters["currentDate"].Value = DateTime.Today;

            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            List<Statistics> jobInfoList = new List<Statistics>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["JobID"]);
                string companyName = reader["CompanyName"].ToString();
                string jobTitle = reader["JobTitle"].ToString();
                string educationalRequirements = reader["EducationalRequirements"].ToString();
                string experienceRequirements = reader["ExperienceRequirements"].ToString();
                DateTime applicationDeadline = Convert.ToDateTime(reader["ApplicationDeadline"]);
                int totalApply = Convert.ToInt32(reader["TotalApply"]);

                Statistics statistics = new Statistics(id, jobTitle, educationalRequirements, experienceRequirements, applicationDeadline, companyName, totalApply);

                jobInfoList.Add(statistics);
            }
            return jobInfoList;
        }

        public int TotalPostedJobs()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(JobID) AS TotalJobs FROM JobInfo where ApplicationDeadline >= (@currentDate)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("currentDate", SqlDbType.DateTime);
            command.Parameters["currentDate"].Value = DateTime.Today;

            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            int totalJobs = 0;

            if (reader.Read())
            {
                totalJobs = Convert.ToInt32(reader["TotalJobs"]);
            }
            return totalJobs;
        }

        public int TotalCompany()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(EmployerID) AS TotalCompany FROM EmployersInfo";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            int totalCompanies = 0;

            if (reader.Read())
            {
                totalCompanies = Convert.ToInt32(reader["TotalCompany"]);
            }
            return totalCompanies;
        }
    }
}