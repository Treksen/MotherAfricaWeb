using Microsoft.AspNetCore.Mvc;
using web.Models.Admin;

namespace web.Controllers
{
    public class AdminController : Controller
    {
        // GET: /admin/register
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        // POST: /admin/register
        [HttpPost]
        public IActionResult RegisterAdmin(AdminRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle registration logic here
                // Save the admin data, etc.

                return RedirectToAction("AdminRegister", "Admin");
            }

            return View(model);


        }
        // Admin Dashboard
        public IActionResult Index()
        {
            // Initialize the IndexModel with sample or dynamic data
            var model = new IndexModel
            {
                WelcomeMessage = "Welcome to the Admin Dashboard",
                JobCount = 10, // Example: Replace with dynamic data from your data source
                TotalUsersRegistered = 25, // Example: Replace with actual data
                TotalApplications = 50, // Example: Replace with actual data
            };

            // Pass the model to the view
            return View(model);
        }

        // Create a list of jobs for demonstration purposes.
        // In a real application, you would retrieve this data from a database or service.
        private static List<ManageJobsModel> jobs = new List<ManageJobsModel>
            {
                new ManageJobsModel
                {
                    JobId = 1,
                    JobTitle = "Software Engineer",
                    CompanyName = "KPA",
                    JobDescription = "Develop and maintain web applications",
                    Location = "Nairobi",
                    PostedDate = DateTime.Now.AddDays(-5),
                    IsOpen = true
                },
                new ManageJobsModel
                {
                    JobId = 2,
                    JobTitle = "Data Analyst",
                    CompanyName = "KPA",
                    JobDescription = "Analyze business data to provide insights",
                    Location = "Mombasa",
                    PostedDate = DateTime.Now.AddDays(-10),
                    IsOpen = false
                },
                new ManageJobsModel
                {
                    JobId = 3,
                    JobTitle = "Project Manager",
                    CompanyName = "KPA.",
                    JobDescription = "Manage construction projects",
                    Location = "Kisumu",
                    PostedDate = DateTime.Now.AddDays(-2),
                    IsOpen = true
                }
            };
        // Manage Job Postings
        public IActionResult ManageJobs()
        {

            // Pass the list of jobs to the view
            return View(jobs);
        }

        // Action to add a new job (GET)
        public IActionResult AddJob()
        {
            return View();
        }
        // Action to add a new job (POST)
        [HttpPost]
        public IActionResult AddJob(ManageJobsModel newJob)
        {
            if (ModelState.IsValid)
            {
                // Assign a new JobId by finding the maximum JobId in the current list and adding 1
                // In a real application, this would likely be handled by the database automatically
                newJob.JobId = jobs.Any() ? jobs.Max(j => j.JobId) + 1 : 1; // Handle case when list is empty

                // Add the new job to the list (or save it to the database)
                jobs.Add(newJob); // Add job to the in-memory list

                TempData["SuccessMessage"] = "Job added successfully.";

                // Redirect to the ManageJobs view after adding
                return RedirectToAction("ManageJobs");
            }

            // If model state is invalid, return the same view with the model to display validation errors
            return View(newJob);
        }
        // GET: /Admin/EditUser/5
        public IActionResult EditJob(int id)
        {
            var job = jobs.FirstOrDefault(u => u.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job); // Pass the user details to the edit view
        }
        // Action to edit a job (POST)
        [HttpPost]
        public IActionResult EditJob(ManageJobsModel updatedJob)
        {
            if (ModelState.IsValid)
            {
                var existingJob = jobs.FirstOrDefault(j => j.JobId == updatedJob.JobId);
                if (existingJob != null)
                {
                    existingJob.JobTitle = updatedJob.JobTitle;
                    existingJob.CompanyName = updatedJob.CompanyName;
                    existingJob.JobDescription = updatedJob.JobDescription;
                    existingJob.Location = updatedJob.Location;
                    existingJob.PostedDate = updatedJob.PostedDate;

                    TempData["SuccessMessage"] = "Job updated successfully.";
                    return RedirectToAction("ManageJobs");
                }

                return NotFound();
            }

            return View(updatedJob);
        }

        // Action to delete a job (POST)
        [HttpPost]
        public IActionResult DeleteJob(int id)
        {
            var job = jobs.FirstOrDefault(j => j.JobId == id);
            if (job != null)
            {
                jobs.Remove(job);
                TempData["SuccessMessage"] = "Job deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Job not found.";
            }

            return RedirectToAction("ManageJobs");
        }


        // View Applications
        private static List<ViewApplicationsModel> applications = new List<ViewApplicationsModel>
        {
            new ViewApplicationsModel
            {
                ApplicationId = 1,
                JobId = 101,
                JobTitle = "Software Developer",
                UserId = 201,
                ApplicantName = "Valentine Nudi",
                ApplicationStatus = "Pending",
                DateApplied = DateTime.Now.AddDays(-7),
                ResumeUrl = "/documents/resume_nudiv.pdf",

            },
            new ViewApplicationsModel
            {
                ApplicationId = 2,
                JobId = 102,
                JobTitle = "Data Analyst",
                UserId = 202,
                ApplicantName = "Emmanuel Amoth",
                ApplicationStatus = "Approved",
                DateApplied = DateTime.Now.AddDays(-10),
                ResumeUrl = "/documents/resume_manua.pdf",

            },
            new ViewApplicationsModel
            {
                ApplicationId = 3,
                JobId = 103,
                JobTitle = "Application Developer",
                UserId = 203,
                ApplicantName = "Dorcus Rumpas",
                ApplicationStatus = "Pending",
                DateApplied = DateTime.Now.AddDays(-7),
                ResumeUrl = "/documents/resume_nudiv.pdf",

            },
            new ViewApplicationsModel
            {
                ApplicationId = 4,
                JobId = 104,
                JobTitle = "Data Scientist",
                UserId = 204,
                ApplicantName = "Eliud Ochieng",
                ApplicationStatus = "Pending",
                DateApplied = DateTime.Now.AddDays(-7),
                ResumeUrl = "/documents/resume_nudiv.pdf",

            },
        };

        // Action to display applications
        public IActionResult ViewApplications()
        {
            // Retrieve the list of applications
            var model = applications; // Replace with actual data retrieval logic
            return View(model);
        }
        // Action to view details of a specific applicant
        public IActionResult ViewApplicantDetails(int id)
        {
            var applicant = applications.FirstOrDefault(a => a.UserId == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // Action to approve an applicant
        public IActionResult ApproveApplicant(int id)
        {
            var applicant = applications.FirstOrDefault(a => a.UserId == id);
            if (applicant != null)
            {
                applicant.ApplicationStatus = "Approved";
            }

            TempData["SuccessMessage"] = "Applicant approved successfully.";
            return RedirectToAction("ViewApplications");
        }

        // Action to reject an applicant
        public IActionResult RejectApplicant(int id)
        {
            var applicant = applications.FirstOrDefault(a => a.UserId == id);
            if (applicant != null)
            {
                applicant.ApplicationStatus = "Rejected";
            }

            TempData["SuccessMessage"] = "Applicant rejected successfully.";
            return RedirectToAction("ViewApplications");
        }

        // Manage Users
        // Simulated database or list to store users
        private static List<ManageUsersModel> users = new List<ManageUsersModel>
        {
        new ManageUsersModel { UserId = 1, FirstName = "Valentine", LastName = "Nudi", Email = "valenudi@gmail.com", Contact= "0712345678", Role = "Admin", IsActive = true },
        new ManageUsersModel { UserId = 2, FirstName = "Emmanuel", LastName = "Amoth", Email = "amothmanu@gmail.com", Contact= "0712345678", Role = "User", IsActive = false }
        };

        // Manage Users
        public IActionResult ManageUsers()
        {
            return View(users); // Pass the list of users to the view
        }

        // GET: /Admin/AddUser
        public IActionResult AddUser()
        {
            return View(); // Show the form to add a new user
        }

        // POST: /Admin/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(ManageUsersModel newUser)
        {
            if (ModelState.IsValid)
            {
                // Simulate adding the user to the list (in a real application, save to the database)
                newUser.UserId = users.Max(u => u.UserId) + 1;
                users.Add(newUser);
                TempData["SuccessMessage"] = "User added successfully!";
                return RedirectToAction("ManageUsers");
            }

            return View(newUser); // Return the view with validation errors if any
        }

        // GET: /Admin/EditUser/5
        public IActionResult EditUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Pass the user details to the edit view
        }

        // POST: /Admin/EditUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(ManageUsersModel updatedUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = users.FirstOrDefault(u => u.UserId == updatedUser.UserId);
                if (existingUser != null)
                {
                    existingUser.FirstName = updatedUser.FirstName;
                    existingUser.LastName = updatedUser.LastName;
                    existingUser.Email = updatedUser.Email;
                    existingUser.Role = updatedUser.Role;
                    existingUser.IsActive = updatedUser.IsActive;

                    TempData["SuccessMessage"] = "User updated successfully!";
                    return RedirectToAction("ManageUsers");
                }

                return NotFound();
            }

            return View(updatedUser); // Return the view with validation errors if any
        }

        // GET: /Admin/DeleteUser/5
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Pass the user details to the delete confirmation view
        }

        // POST: /Admin/DeleteUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUserConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                users.Remove(user);
                TempData["SuccessMessage"] = "User deleted successfully!";
                return RedirectToAction("ManageUsers");
            }

            return NotFound();
        }

        // InternalAdvert
        // In a real application, you would retrieve this data from a database or service.
        private static List<ManageJobsModel> jobs2 = new List<ManageJobsModel>
            {
                new ManageJobsModel
                {
                    JobId = 1,
                    JobTitle = "Software Developer",
                    CompanyName = "KPA",
                    JobDescription = "Develop and maintain web applications",
                    Location = "Nairobi",
                    PostedDate = DateTime.Now.AddDays(-5),
                    IsOpen = true
                },
                new ManageJobsModel
                {
                    JobId = 2,
                    JobTitle = "Data Analyst",
                    CompanyName = "KPA",
                    JobDescription = "Analyze business data to provide insights",
                    Location = "Mombasa",
                    PostedDate = DateTime.Now.AddDays(-10),
                    IsOpen = false
                },
                new ManageJobsModel
                {
                    JobId = 3,
                    JobTitle = "Project Manager",
                    CompanyName = "KPA.",
                    JobDescription = "Manage construction projects",
                    Location = "Kisumu",
                    PostedDate = DateTime.Now.AddDays(-2),
                    IsOpen = true
                }
            };
        // Manage Job Postings
        public IActionResult InternalAdvert()
        {

            // Pass the list of jobs to the view
            return View(jobs);
        }

        // Action to add a new job (GET)
        public IActionResult AddJob2()
        {
            return View();
        }
        // Action to add a new job (POST)
        [HttpPost]
        public IActionResult AddJob2(ManageJobsModel newJob)
        {
            if (ModelState.IsValid)
            {
                // Assign a new JobId by finding the maximum JobId in the current list and adding 1
                // In a real application, this would likely be handled by the database automatically
                newJob.JobId = jobs.Any() ? jobs.Max(j => j.JobId) + 1 : 1; // Handle case when list is empty

                // Add the new job to the list (or save it to the database)
                jobs.Add(newJob); // Add job to the in-memory list

                TempData["SuccessMessage"] = "Job added successfully.";

                // Redirect to the ManageJobs view after adding
                return RedirectToAction("InternalAdvert");
            }

            // If model state is invalid, return the same view with the model to display validation errors
            return View(newJob);
        }
        // Action to edit a job (POST)
        [HttpPost]
        public IActionResult EditJob2(ManageJobsModel updatedJob)
        {
            if (ModelState.IsValid)
            {
                var existingJob = jobs.FirstOrDefault(j => j.JobId == updatedJob.JobId);
                if (existingJob != null)
                {
                    existingJob.JobTitle = updatedJob.JobTitle;
                    existingJob.CompanyName = updatedJob.CompanyName;
                    existingJob.JobDescription = updatedJob.JobDescription;
                    existingJob.Location = updatedJob.Location;
                    existingJob.PostedDate = updatedJob.PostedDate;

                    TempData["SuccessMessage"] = "Job updated successfully.";
                    return RedirectToAction("InternalAdvert");
                }

                return NotFound();
            }

            return View(updatedJob);
        }

        // Action to delete a job (POST)
        [HttpPost]
        public IActionResult DeleteJob2(int id)
        {
            var job = jobs.FirstOrDefault(j => j.JobId == id);
            if (job != null)
            {
                jobs.Remove(job);
                TempData["SuccessMessage"] = "Job deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Job not found.";
            }

            return RedirectToAction("InternalAdvert");
        }
        // ExternalAdvert
        // In a real application, you would retrieve this data from a database or service.
        private static List<ManageJobsModel> jobs3 = new List<ManageJobsModel>
            {
                new ManageJobsModel
                {
                    JobId = 4,
                    JobTitle = "Software Developer",
                    CompanyName = "KPA",
                    JobDescription = "Develop and maintain web applications",
                    Location = "Kiambu",
                    PostedDate = DateTime.Now.AddDays(-5),
                    IsOpen = true
                },
                new ManageJobsModel
                {
                    JobId = 5,
                    JobTitle = "Data scientist",
                    CompanyName = "KPA",
                    JobDescription = "Analyze business data to provide insights",
                    Location = "Mombasa",
                    PostedDate = DateTime.Now.AddDays(-10),
                    IsOpen = false
                },
                new ManageJobsModel
                {
                    JobId = 6,
                    JobTitle = "Project organizer",
                    CompanyName = "KPA.",
                    JobDescription = "Manage construction projects",
                    Location = "Kisumu",
                    PostedDate = DateTime.Now.AddDays(-2),
                    IsOpen = true
                }
            };
        // Manage Job Postings
        public IActionResult ExternalAdvert()
        {

            // Pass the list of jobs to the view
            return View(jobs);
        }

        // Action to add a new job (GET)
        public IActionResult AddJob3()
        {
            return View();
        }
        // Action to add a new job (POST)
        [HttpPost]
        public IActionResult AddJob3(ManageJobsModel newJob)
        {
            if (ModelState.IsValid)
            {
                // Assign a new JobId by finding the maximum JobId in the current list and adding 1
                // In a real application, this would likely be handled by the database automatically
                newJob.JobId = jobs.Any() ? jobs.Max(j => j.JobId) + 1 : 1; // Handle case when list is empty

                // Add the new job to the list (or save it to the database)
                jobs.Add(newJob); // Add job to the in-memory list

                TempData["SuccessMessage"] = "Job added successfully.";

                // Redirect to the ManageJobs view after adding
                return RedirectToAction("ExternlAdvert");
            }

            // If model state is invalid, return the same view with the model to display validation errors
            return View(newJob);
        }
        // Action to edit a job (POST)
        [HttpPost]
        public IActionResult EditJob3(ManageJobsModel updatedJob)
        {
            if (ModelState.IsValid)
            {
                var existingJob = jobs.FirstOrDefault(j => j.JobId == updatedJob.JobId);
                if (existingJob != null)
                {
                    existingJob.JobTitle = updatedJob.JobTitle;
                    existingJob.CompanyName = updatedJob.CompanyName;
                    existingJob.JobDescription = updatedJob.JobDescription;
                    existingJob.Location = updatedJob.Location;
                    existingJob.PostedDate = updatedJob.PostedDate;

                    TempData["SuccessMessage"] = "Job updated successfully.";
                    return RedirectToAction("ExternalAdvert");
                }

                return NotFound();
            }

            return View(updatedJob);
        }

        // Action to delete a job (POST)
        [HttpPost]
        public IActionResult DeleteJob3(int id)
        {
            var job = jobs.FirstOrDefault(j => j.JobId == id);
            if (job != null)
            {
                jobs.Remove(job);
                TempData["SuccessMessage"] = "Job deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Job not found.";
            }

            return RedirectToAction("ExternalAdvert");
        }
    }
}