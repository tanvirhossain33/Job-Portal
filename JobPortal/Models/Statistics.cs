using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class Statistics
    {
        public int JobID { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Job Description")]
        [DataType(DataType.MultilineText)]
        public string JobDescription { get; set; }

        [Required]
        [DisplayName("Job Nature")]
        public string JobNature { get; set; }

        [Required]
        [DisplayName("Educational Requirements")]
        [DataType(DataType.MultilineText)]
        public string EducationalRequirements { get; set; }

        [Required]
        [DisplayName("Experience Requirements")]
        [DataType(DataType.MultilineText)]
        public string ExperienceRequirements { get; set; }

        [Required]
        [DisplayName("Additional Requirements")]
        [DataType(DataType.MultilineText)]
        public string AdditionalRequirements { get; set; }

        [Required]
        [DisplayName("Number Of Vacancies")]
        public int NoOfVacancies { get; set; }

        [Required]
        [DisplayName("Salary Range")]
        public string SalaryRange { get; set; }

        [Required]
        [DisplayName("Other Benefit")]
        [DataType(DataType.MultilineText)]
        public string OtherBenefit { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Application Deadline")]
        public DateTime ApplicationDeadline { get; set; }

        public int EmployerID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Publish Time")]
        public DateTime PublishTime { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("From Time")]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("To Time")]
        public DateTime To { get; set; }

        [DisplayName("Total Apply ")]
        public int TotalApply { get; set; }

        [DisplayName("Total Live Jobs")]
        public int TotalPostedJobs { get; set; }

        [DisplayName("Companies")]
        public int TotalCompany { get; set; }

        public Statistics()
        {
        }

        public Statistics(int id, string jobTitle, string educationalRequirements, string experienceRequirements, DateTime applicationDeadline, string companyName, int totalApply)
        {
            this.JobID = id;
            this.JobTitle = jobTitle;
            this.EducationalRequirements = educationalRequirements;
            this.ExperienceRequirements = experienceRequirements;
            this.ApplicationDeadline = applicationDeadline;
            this.CompanyName = companyName;
            this.TotalApply = totalApply;
        }
        
    }
}