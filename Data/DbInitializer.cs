using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;
namespace WebApplication5.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebsiteContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var Users = new User[]
            {
            new User{UserID=1, FirstName="Carson",LastName="Alexander"},
            new User{UserID=2, FirstName="Meredith",LastName="Alonso"},
            new User{UserID=3, FirstName="Arturo",LastName="Anand"},
            new User{UserID=4, FirstName="Gytis",LastName="Barzdukas"},
            new User{UserID=5, FirstName="Yan",LastName="Li"},
            new User{UserID=6, FirstName="Peggy",LastName="Justice"},
            new User{UserID=7, FirstName="Laura",LastName="Norman"},
            new User{UserID=8, FirstName="Nino",LastName="Olivetto"}
            };
            foreach (User s in Users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var Complaints = new Complaint[]
            {
            new Complaint{UserID=1,ComplaintText="Chemistry"},
            new Complaint{UserID=4,ComplaintText="Microeconomics"},
            new Complaint{UserID=4,ComplaintText="Macroeconomics"},
            new Complaint{UserID=1,ComplaintText="Calculus"},
            new Complaint{UserID=3,ComplaintText="Trigonometry"},
            new Complaint{UserID=2,ComplaintText="Composition"},
            new Complaint{UserID=2,ComplaintText="Literature"}
            };
            foreach (Complaint c in Complaints)
            {
                context.Complaints.Add(c);
            }
            context.SaveChanges();
        }
    }
}
