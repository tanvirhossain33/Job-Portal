using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class StatisticsManager
    {
        StatisticsGetway statisticsGetway = new StatisticsGetway();
        public List<Statistics> GetJobInfo()
        {
            return statisticsGetway.GetJobInfo();
        }

        public int TotalPostedJobs()
        {
            return statisticsGetway.TotalPostedJobs();
        }

        public int TotalCompany()
        {
            return statisticsGetway.TotalCompany();
        }

    }
}