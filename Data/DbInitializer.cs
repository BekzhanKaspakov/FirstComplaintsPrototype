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
                new User{UserID=1, OrganizationID=1, FirstName="Carson",LastName="Alexander"},
                new User{UserID=2, OrganizationID=1, FirstName="Meredith",LastName="Alonso"},
                new User{UserID=3, OrganizationID=2, FirstName="Arturo",LastName="Anand"},
                new User{UserID=4, OrganizationID=2, FirstName="Gytis",LastName="Barzdukas"},
                new User{UserID=5, OrganizationID=3, FirstName="Yan",LastName="Li"},
                new User{UserID=6, OrganizationID=3, FirstName="Peggy",LastName="Justice"},
                new User{UserID=7, OrganizationID=4, FirstName="Laura",LastName="Norman"},
                new User{UserID=8, OrganizationID=4, FirstName="Nino",LastName="Olivetto"}
            };
            foreach (User s in Users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var Complaints = new Complaint[]
            {
                new Complaint{ID = 1, OrganizationID=1, ComplaintText="Nice"},
				new Complaint{ID = 2, OrganizationID=1, ComplaintText="Nice"},
				new Complaint{ID = 3, OrganizationID=2, ComplaintText="Nice"},
				new Complaint{ID = 4, OrganizationID=2, ComplaintText="Nice"},
				new Complaint{ID = 5, OrganizationID=3, ComplaintText="Nice"},
				new Complaint{ID = 6, OrganizationID=3, ComplaintText="Nice"},
				new Complaint{ID = 7, OrganizationID=4, ComplaintText="Nice"}
            };
            foreach (Complaint c in Complaints)
            {
                context.Complaints.Add(c);
            }
            context.SaveChanges();

            var Organizations = new Organization[]
            {
                new Organization{OrganizationID=1, OrganizationName="1st FLoor"},
                new Organization{OrganizationID=2, OrganizationName="2nd Floor"},
                new Organization{OrganizationID=3, OrganizationName="3rd Floor"},
                new Organization{OrganizationID=4, OrganizationName="4th Floor"}
            };
            foreach (Organization c in Organizations)
            {
                context.Organization.Add(c);
            }
            context.SaveChanges();
        }
    }
}
