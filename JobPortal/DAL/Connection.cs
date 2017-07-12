using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.DAL
{
    public class Connection
    {

        public string GetConnection()
        {
            string connectionString = @"Server=.\SQLEXPRESS; Database = JobPortal; Integrated Security=true";
            //string connectionString = @"Data Source=mssql4.gear.host;Initial Catalog=jobsportal;User ID=jobsportal;Password=Yb5lp-~q8l57" ;

            return connectionString;

        }
    }
}