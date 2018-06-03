using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }


        public ICollection<Complaint> Complaints = new List<Complaint>();
        public ICollection<User> Users = new List<User>();
    }
}
