using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models;

namespace WebApplication5.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrganizationID { get; set; }
        public string Email { get; set; }
        public Organization Organization { get; set; }

        public ICollection<Complaint> Complaints = new List<Complaint>();

        
    }
}
