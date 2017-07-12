using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class SeekerJobInterest
    {
        public int ID { get; set; }
        public int SeekerID { get; set; }
        public int JobID { get; set; }

        public SeekerJobInterest()
        {
            
        }

        public SeekerJobInterest(int seekerID, int jobID)
        {
            this.SeekerID = seekerID;
            this.JobID = jobID;
        }
    }
}