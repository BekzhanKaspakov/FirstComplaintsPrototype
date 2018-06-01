using System;
using System.Collections.Generic;
using WebApplication5.Models;


namespace WebApplication5.Models
{
    public class Complaint
    {
        public int ID { get; set; }
        
        public int OrganizationID { get; set; }

        public string ComplaintText { get; set; }

        public Organization Organization { get; set; }

    }
}