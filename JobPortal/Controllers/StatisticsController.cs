using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using JobPortal.BLL;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class StatisticsController : Controller
    {
        StatisticsManager statisticsManager = new StatisticsManager();
        JobManager jobManager = new JobManager();

        public ActionResult Index()
        {
            int totalPostedJobs = statisticsManager.TotalPostedJobs();
            int totalCompany = statisticsManager.TotalCompany();
            List<Statistics> jobList = statisticsManager.GetJobInfo();

            ViewBag.TotalLiveJobs = totalPostedJobs;
            ViewBag.totalCompanies = totalCompany;
            ViewBag.jobList = jobList;

            return View();
        }

        public ActionResult JobDetailsView(int id)
        {
            List<JobInfo> jobInfoList = jobManager.GetDetailJobInfo(id);

            ViewBag.jobDetails = jobInfoList;

            return View();
        }
        
	}
}