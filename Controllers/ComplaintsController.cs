using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly WebsiteContext _context;

        public ComplaintsController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: Complaints
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Complaints.Include(c => c.Organization);
            return View(await websiteContext.ToListAsync());
        }

        // GET: Complaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints
                .Include(c => c.Organization)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }

        // GET: Complaints/Create
        public IActionResult Create()
        {
            ViewData["OrganizationID"] = new SelectList(_context.Organization, "OrganizationID", "OrganizationID");
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrganizationID,ComplaintText")] Complaint complaint)
        {
            

            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("************HUIASASAASASASA*****************\n");

                SqlConnection sqlConnection1 = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=NewDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = $"SELECT Email FROM [User] WHERE OrganizationID = {complaint.OrganizationID}";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.
                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("{0}", reader[0]));
                    System.Diagnostics.Debug.WriteLine("************Message Sent*****************\n");
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("bekzhan.kaspakov@gmail.com");
                    mail.To.Add(String.Format("{0}", reader[0]));
                    mail.Subject = "Complaint Mail";
                    mail.Body = complaint.ComplaintText;


                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("bekzhan.kaspakov", "watsamatsate98");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    Console.WriteLine("Message Sent\n");
                }
                sqlConnection1.Close();
              
                //{
                //    System.Diagnostics.Debug.WriteLine("************Message Sent*****************\n");
                //    MailMessage mail = new MailMessage();
                //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //    mail.From = new MailAddress("bekzhan.kaspakov@gmail.com");
                //    mail.To.Add(u.Email);
                //    mail.Subject = "Test Mail";
                //    mail.Body = "This is for testing SMTP mail from GMAIL";


                //    SmtpServer.Port = 587;
                //    SmtpServer.Credentials = new System.Net.NetworkCredential("bekzhan.kaspakov", "watsamatsate98");
                //    SmtpServer.EnableSsl = true;

                //    SmtpServer.Send(mail);
                //    Console.WriteLine("Message Sent\n");

                //}
                _context.Add(complaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationID"] = new SelectList(_context.Organization, "OrganizationID", "OrganizationID", complaint.OrganizationID);
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints.SingleOrDefaultAsync(m => m.ID == id);
            if (complaint == null)
            {
                return NotFound();
            }
            ViewData["OrganizationID"] = new SelectList(_context.Organization, "OrganizationID", "OrganizationID", complaint.OrganizationID);
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrganizationID,ComplaintText")] Complaint complaint)
        {
            if (id != complaint.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintExists(complaint.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationID"] = new SelectList(_context.Organization, "OrganizationID", "OrganizationID", complaint.OrganizationID);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints
                .Include(c => c.Organization)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complaint = await _context.Complaints.SingleOrDefaultAsync(m => m.ID == id);
            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplaintExists(int id)
        {
            return _context.Complaints.Any(e => e.ID == id);
        }
    }
}
