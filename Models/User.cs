using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        public ICollection<Complaint> Complaints { get; set; }
    }
}
