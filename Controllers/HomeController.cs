using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECAN_CRF.Models;
using ECAN_CRF.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ECAN_CRF.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbcontext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public static string Businessname = "ECAN CRF";
        public static string Address = "P.O BOX 21 Kenya";
        public static string FirstTell = "0110 090388";
        public static string secondtTell = "+0215 46 32 21";
        public static string businessemail = "kilithecomputerguy@gmail.com";
        public static string website = "www.ecankenya.com/";
        public HomeController(AppDbcontext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public class PieData
        {
            public string xValue;
            public double yValue;
            public string text;
        }
        public async Task<IActionResult> Dashboard()
        {
           var centerdata= _context.centes.Where(k => k.IsDeleted == false).ToList();

            General general = new General();
            general.studens = _context.studens.Where(k => k.isDeleted == false).ToList();
            general.Centers = centerdata;
            general.sponsers= _context.sponsers.Where(k => k.IsDeleted == false).ToList();
            general.schools= _context.schools.Where(k => k.IsDeleted == false).ToList();
         //   general.events = _context.events.Where(k => k.Isdelered == false).ToList();
            List<PieData> chartData = new List<PieData>();
            chartData.Clear();
            foreach(var itemm in centerdata)
            {
                var studentscoubt = _context.studens.Where(k => k.strCenterId == itemm.strId&&k.isDeleted==false).Count();
                var newdata = new PieData
                {
                    text = itemm.CenterName,
                    xValue = "Students",
                    yValue = studentscoubt
                };
                chartData.Add(newdata);
            }
            ViewBag.dataSourcewww = chartData;

            List<Studens> studens = new List<Studens>();
            studens.Clear();

            var data = _context.studens.Where(k => k.isDeleted == false).ToList();
            foreach (var item in data)
            {
                var center = "";
                var sponsor = "";
                var schoool = "";
                var centerrr = await _context.centes.FirstOrDefaultAsync(k => k.strId == item.strCenterId);
                if (centerrr != null)
                {
                    center = centerrr.CenterName;
                }
                var scho = await _context.schools.FirstOrDefaultAsync(k => k.strId == item.strSchoolId);
                if (scho != null)
                {
                    schoool = scho.Name;
                }

                var spo = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == item.strSponserId);
                if (spo != null)
                {
                    sponsor = spo.stName;
                }
                var newdata = new Studens
                {
                    isDeleted = item.isDeleted,
                    ImageUrl = item.ImageUrl,
                    strADMDate = item.strADMDate,
                    strADNo = item.strADNo,
                    strCenterId = center,
                    strCgrade_Class = item.strCgrade_Class,
                    strDateOfBirth = item.strDateOfBirth,
                    strguardianPhone = item.strguardianPhone,
                    strGuarduianName = item.strGuarduianName,
                    strId = item.strId,
                    strName = item.strName,
                    strSchoolId = schoool,
                    strSponserId = sponsor
                };
                studens.Add(newdata);
            }
            
            ViewBag.Students = studens;
            return View(general);
        }
        public async Task<IActionResult> FieldworkerDashboard()
        {
            var centerId = "";
            var user = await _context.Users.FirstOrDefaultAsync(k => k.strId == User.Identity.Name);
            if (user != null)
            {
                centerId = user.CenterId;
            }

           var centerdata= _context.centes.Where(k => k.IsDeleted == false).ToList();

            General general = new General();
            general.studens = _context.studens.Where(k => k.isDeleted == false&&k.strCenterId== centerId).ToList();
            general.Centers = centerdata;
            general.sponsers= _context.sponsers.Where(k => k.IsDeleted == false).ToList();
            general.schools= _context.schools.Where(k => k.IsDeleted == false&&k.CenterId== centerId).ToList();
         //   general.events = _context.events.Where(k => k.Isdelered == false).ToList();
         
            List<Studens> studens = new List<Studens>();
            studens.Clear();

            var data = _context.studens.Where(k => k.isDeleted == false&&k.strCenterId== centerId).ToList();
            foreach (var item in data)
            {
                var center = "";
                var sponsor = "";
                var schoool = "";
                var centerrr = await _context.centes.FirstOrDefaultAsync(k => k.strId == item.strCenterId);
                if (centerrr != null)
                {
                    center = centerrr.CenterName;
                }
                var scho = await _context.schools.FirstOrDefaultAsync(k => k.strId == item.strSchoolId);
                if (scho != null)
                {
                    schoool = scho.Name;
                }

                var spo = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == item.strSponserId);
                if (spo != null)
                {
                    sponsor = spo.stName;
                }
                var newdata = new Studens
                {
                    isDeleted = item.isDeleted,
                    ImageUrl = item.ImageUrl,
                    strADMDate = item.strADMDate,
                    strADNo = item.strADNo,
                    strCenterId = center,
                    strCgrade_Class = item.strCgrade_Class,
                    strDateOfBirth = item.strDateOfBirth,
                    strguardianPhone = item.strguardianPhone,
                    strGuarduianName = item.strGuarduianName,
                    strId = item.strId,
                    strName = item.strName,
                    strSchoolId = schoool,
                    strSponserId = sponsor
                };
                studens.Add(newdata);
            }

          
            ViewBag.Students = studens;
            return View(general);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cenyters()
        {
            ViewBag.centers = _context.centes.Where(k => k.IsDeleted == false).ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var centerId = "null";
            if (User.IsInRole("Field Worker")==true)
            {
               
                var user = await _context.Users.FirstOrDefaultAsync(k => k.strId == User.Identity.Name);
                if (user != null)
                {
                    centerId = user.CenterId;
                }
            }

            List<Studens> studens = new List<Studens>();
            studens.Clear();
            var data = studens;
            if (centerId == "null")
            {
                 data = _context.studens.Where(k => k.isDeleted == false).ToList();
            }
            else
            {
                data = _context.studens.Where(k => k.isDeleted == false&&k.strCenterId== centerId).ToList();
            }
           
            foreach(var item in data)
            {
                var center = "";
                var sponsor = "";
                var schoool = "";
                var centerrr = await _context.centes.FirstOrDefaultAsync(k => k.strId == item.strCenterId);
                if (centerrr != null)
                {
                    center = centerrr.CenterName;
                }
                var scho = await _context.schools.FirstOrDefaultAsync(k => k.strId == item.strSchoolId);
                if (scho != null)
                {
                    schoool = scho.Name;
                }

                var spo = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == item.strSponserId);
                if (spo != null)
                {
                    sponsor = spo.stName;
                }
                var newdata = new Studens
                {
                    isDeleted = item.isDeleted,
                    ImageUrl = item.ImageUrl,
                    strADMDate = item.strADMDate,
                    strADNo = item.strADNo,
                    strCenterId = center,
                    strCgrade_Class = item.strCgrade_Class,
                    strDateOfBirth = item.strDateOfBirth,
                    strguardianPhone = item.strguardianPhone,
                    strGuarduianName = item.strGuarduianName,
                    strId = item.strId,
                    strName = item.strName,
                    strSchoolId = schoool,
                    strSponserId = sponsor
                };
                studens.Add(newdata);
            }
            
            ViewBag.schools = _context.schools.Where(k => k.IsDeleted == false).ToList();
            ViewBag.Students = studens;
            ViewBag.Sponsor = _context.sponsers.Where(k => k.IsDeleted == false).ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StudentsEdit(string id)
        {
            var data = _context.studens.Where(k => k.isDeleted == false).ToList();
            ViewBag.schools = _context.schools.Where(k => k.IsDeleted == false).ToList();
            ViewBag.Sponsor = _context.sponsers.Where(k => k.IsDeleted == false).ToList();

            var student= await _context.studens.FirstOrDefaultAsync(k => k.strId == id);
            if (student != null)
            {

                return View(student);
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                return Redirect("~/Home/Students");
            }      
          
                    }


        [HttpPost]
        public async Task<IActionResult> StudentsCreate(Studens studens)
        {
            var centerid = "";
            if (!ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(studens.ImageFile.FileName);
                string extension = Path.GetExtension(studens.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/StudentsImages/", filename);
                var test = "http://ecancrf-001-site1.anytempurl.com/StudentsImages/" + filename;


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await studens.ImageFile.CopyToAsync(fileStream);
                }

                var school = await _context.schools.FirstOrDefaultAsync(k => k.strId == studens.strSchoolId);
                if (school != null)
                {
                    centerid = school.CenterId;
                }
                studens.ImageUrl = test;
                studens.strCenterId = centerid;
                _context.Add(studens);
                await _context.SaveChangesAsync();

                TempData["success"] = "Student added Successfully";

            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }

            return Redirect("~/Home/Students");
        }
        [HttpPost]
        public async Task<IActionResult> StudentsEditInfo(Studens studens)
        {
            var centerid = "";
            if (!ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(studens.ImageFile.FileName);
                string extension = Path.GetExtension(studens.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/StudentsImages/", filename);
                var test = "http://ecancrf-001-site1.anytempurl.com/StudentsImages/" + filename;


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await studens.ImageFile.CopyToAsync(fileStream);
                }

                var school = await _context.schools.FirstOrDefaultAsync(k => k.strId == studens.strSchoolId);
                if (school != null)
                {
                    centerid = school.CenterId;
                }
                studens.ImageUrl = test;
                studens.strCenterId = centerid;
                _context.Update(studens);
                await _context.SaveChangesAsync();

                TempData["success"] = "Student info Updated Successfully";

            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }

            return Redirect("~/Home/Students");
        }

        [HttpGet]
        public IActionResult Sponsors()
        {
            ViewBag.Sponsors = _context.sponsers.Where(k => k.IsDeleted == false).ToList();
            return View();
        }
        [HttpGet]
        public  async Task<IActionResult> Schools()
        {
            ViewBag.centersdata = _context.centes.Where(k => k.IsDeleted == false).ToList();
            List<SchoolsTwo> list = new List<SchoolsTwo>();
            list.Clear();
            var data = _context.schools.Where(k => k.IsDeleted == false).ToList();
            foreach(var item in data)
            { var center = "n/a";
                var centerinfo = await _context.centes.FirstOrDefaultAsync(k => k.strId == item.CenterId);
                if (centerinfo != null)
                {
                    center = centerinfo.CenterName ;

                }

                var centerrrr = new SchoolsTwo
                {
                    CenterId = center,
                    IsDeleted = item.IsDeleted,
                    Name = item.Name,
                    strId = item.strId,
                     CeterIdOriginal= item.CenterId

                };
                list.Add(centerrrr);
            }


            ViewBag.schools = list;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Cenyters(Centers centers)
        {
            if (centers != null)
            {
                _context.centes.Add(centers);
                await _context.SaveChangesAsync();
                TempData["success"] = "Center added Successfully";

            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Cenyters");
        }

        [HttpPost]
        public async Task<IActionResult> Schools(Schools schools)
        {
            if (schools != null)
            {
                _context.schools.Add(schools);
                await _context.SaveChangesAsync();
                TempData["success"] = "School added Successfully";

            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Schools");
        }

        [HttpGet]
        public async Task<IActionResult> StudentDetails(string id)
        {
            var center = "";
            var sponsor = "";
            var schoool = "";
          

            var student = await _context.studens.FirstOrDefaultAsync(k => k.strId == id);

            if (student != null)
            {
                var centerrr = await _context.centes.FirstOrDefaultAsync(k => k.strId == student.strCenterId);
                if (centerrr != null)
                {
                    center = centerrr.CenterName;
                }
                var scho = await _context.schools.FirstOrDefaultAsync(k => k.strId == student.strSchoolId);
                if (scho != null)
                {
                    schoool = scho.Name;
                }

                var spo = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == student.strSponserId);
                if (spo != null)
                {
                    sponsor = spo.stName;
                }
                student.strSchoolId = schoool;
                student.strSponserId = sponsor;
                student.strCenterId = center;
                ViewBag.Events = _context.events.Where(k => k.Isdelered == false&&k.strStudentId==id).OrderByDescending(k=>k.strDate).ToList();
                return View(student);

            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Students");
        }


        [HttpPost]
        public async Task<IActionResult> EventCreation(string textarea,string studentId,IFormFile image)
        {
            var test = "";
            if (image!=null)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(image.FileName);
                string extension = Path.GetExtension(image.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/SponsersImages/", filename);
                test = "http://ecancrf-001-site1.anytempurl.com/SponsersImages/" + filename;


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
           

         //   sponsers.stImageURl = test;
            var newrecord = new Events
            {
                Isdelered = false,
                strDate = DateTime.UtcNow.AddHours(3),
                strEvent = textarea,
                strId = Guid.NewGuid().ToString(),
                strStudentId = studentId,
                 ImageUrl= test
            };
            _context.events.Add(newrecord);
            await _context.SaveChangesAsync();
            return Redirect("~/Home/StudentDetails/"+studentId);
        }

        [HttpPost]
        public async Task<IActionResult> EditCenter(string strId,string name,string code)
        {
            var centre = await _context.centes.FirstOrDefaultAsync(k => k.strId == strId);
            if (centre != null)
            {
                centre.CenterName = name;
                centre.CenterCode = code;
                _context.centes.Update(centre);
                await _context.SaveChangesAsync();
                TempData["success"] = "Center Updated Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Cenyters");
        }

        [HttpGet]
        public async Task<IActionResult> EditSponsers(string id)
        {
            var sponsor = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == id);
            if (sponsor != null)
            {              
               
                return View(sponsor);
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                return Redirect("~/Home/Sponsors");
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> SponsorsCreate(Sponsers sponsers)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(sponsers.ImageFile.FileName);
                string extension = Path.GetExtension(sponsers.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/SponsersImages/", filename);
                var test = "http://ecancrf-001-site1.anytempurl.com/SponsersImages/" + filename;


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await sponsers.ImageFile.CopyToAsync(fileStream);
                }

                sponsers.stImageURl = test;
                _context.sponsers.Add(sponsers);
                await _context.SaveChangesAsync();
                TempData["success"] = "Sponsor Added Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                

            }
            return Redirect("~/Home/Sponsors");
        }
        public class UserRole
        {
            public string Role { get; set; }
        }
        [HttpGet]
        public async Task<IActionResult> SystemUsers()
        {
            List<UserRole> userRoles = new List<UserRole>
            {
                new UserRole{ Role="Supper Admin"},
                new UserRole{ Role="Admin"},
                new UserRole{ Role="Field Worker"},
            };

            var SystemUsers =  _context.Users.Where(k=>k.isDeleted==false).ToList();
          
            ViewBag.Role = userRoles;
            List<Centers> centers = new List<Centers>();
            centers.Clear();
            centers.Add(new Centers { strId = "test", IsDeleted = false, CenterCode = "test", CenterName = "Can View All" });
            foreach (var itemmmm in _context.centes.Where(k => k.IsDeleted == false).ToList())
            {
                centers.Add(itemmmm);

            }
            ViewBag.Center = centers;
            General general = new General();
            general.Centers = _context.centes.ToList();
            general.Users = SystemUsers;
            return View(general);
        }
        [HttpPost]
        public async Task<IActionResult> SystemUsers(string fullname,string username,string Role,string Password,string CenterName)
        {
            var centerid = "";
            if (CenterName != "test")
            {
                centerid = CenterName;
            }
            var newuser = new Users
            {
                isDeleted = false,
                strId = Guid.NewGuid().ToString(),
                strName = fullname,
                strPassword = Password,
                strRole = Role,
                strUsername = username,
                 CenterId= centerid
            };
            _context.Users.Add(newuser);
            await _context.SaveChangesAsync();

            TempData["success"] = "User added to the system Successfully..";
            return Redirect("~/Home/SystemUsers");
           
        }

        [HttpGet]
        public async Task<IActionResult> EditSponsors(string id)
        {
            var spnsor = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == id);
            if (spnsor != null)
            {
                return View(spnsor);
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                return Redirect("~/Home/Sponsors");
          
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> EditSChoolinfo(string Id,string name,string CenterId)
        {
           
            var schools = await _context.schools.FirstOrDefaultAsync(k => k.strId == Id);
            if (schools != null)
            {
                var centerIdddd = "CenterId";
                var centerrrrrr = await _context.centes.FirstOrDefaultAsync(k => k.CenterName == CenterId);
                if (centerrrrrr != null)
                {
                    centerIdddd = centerrrrrr.strId;
                }
                schools.Name = name;
                schools.strId = Id;
                schools.CenterId = centerIdddd;
                _context.schools.Update(schools);
                await _context.SaveChangesAsync();
                TempData["success"] = "School info updated Successfully..";
                return Redirect("~/Home/Schools" );
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                return Redirect("~/Home/Schools/"+ Id);

            }
           
        }

        [HttpPost]
        public async Task<IActionResult> EditSponsors(Sponsers sponsers)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(sponsers.ImageFile.FileName);
                string extension = Path.GetExtension(sponsers.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/SponsersImages/", filename);
                var test = "http://ecancrf-001-site1.anytempurl.com/SponsersImages/" + filename;


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await sponsers.ImageFile.CopyToAsync(fileStream);
                }

                sponsers.stImageURl = test;
                _context.sponsers.Update(sponsers);
                await _context.SaveChangesAsync();
                TempData["success"] = "Sponsor Info Updated Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                

            }
            return Redirect("~/Home/Sponsors");
        }


        [HttpGet]
        public async Task<IActionResult> EditSystemUsetr(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(k => k.strId == id);
            ViewBag.Center = _context.centes.Where(k => k.IsDeleted == false).ToList();
            List<UserRole> userRoles = new List<UserRole>
            {
                new UserRole{ Role="Supper Admin"},
                new UserRole{ Role="Admin"},
                new UserRole{ Role="Field Worker"},
            };
              ViewBag.Role = userRoles;
            if (user != null)
            {
                return View(user);
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
                return Redirect("~/Home/SystemUsers");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(Users users)
        {
            if (users.strId != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(k => k.strId == users.strId);
                if (user != null)
                {
                    user.strName = users.strName;
                    user.strUsername = users.strUsername;
                    user.strRole = users.strRole;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "User info was updated successfully";

                }
                else
                {
                    TempData["Err"] = "Something went wrong..";

                }
            }
           
            return Redirect("~/Home/SystemUsers");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCenter(string id)
        {
            var center = await _context.centes.FirstOrDefaultAsync(k => k.strId == id);
            if (center != null)
            {
                center.IsDeleted = true;
                _context.centes.Update(center);
                await _context.SaveChangesAsync();
                TempData["success"] = "Center Deleted Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Cenyters");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSystemUser(string id)
        {
            var center = await _context.Users.FirstOrDefaultAsync(k => k.strId == id);
            if (center != null)
            {
                center.isDeleted = true;
                _context.Users.Update(center);
                await _context.SaveChangesAsync();
                TempData["success"] = "User Removed Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/SystemUsers");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudenty(string id)
        {
            var center = await _context.studens.FirstOrDefaultAsync(k => k.strId == id);
            if (center != null)
            {
                center.isDeleted = true;
                _context.studens.Update(center);
                await _context.SaveChangesAsync();
                TempData["success"] = "Student Deleted Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Students");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSponsor(string id)
        {
            var Sponsor = await _context.sponsers.FirstOrDefaultAsync(k => k.strId == id);
            if (Sponsor != null)
            {
                Sponsor.IsDeleted = true;
                _context.sponsers.Update(Sponsor);
                await _context.SaveChangesAsync();
                TempData["success"] = "Sponsor Deleted Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Sponsors");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSchool(string id)
        {
            var School = await _context.schools.FirstOrDefaultAsync(k => k.strId == id);
            if (School != null)
            {
                School.IsDeleted = true;
                _context.schools.Update(School);
                await _context.SaveChangesAsync();
                TempData["success"] = "School Deleted Successfully";
            }
            else
            {
                TempData["Err"] = "Something went wrong..";
            }
            return Redirect("~/Home/Schools");
        }

        [AllowAnonymous]
        public IActionResult LoginUser(Users user)
        {
            // return Json(user);
            if (user.strUsername == null || user.strUsername == null)
            {
                TempData["Err"] = "Username or password fields cannot be empty";
                return Redirect("~/Home/Index");
            }
            // var pass = user.strUserName;

            TokenProvider TokenProvider = new TokenProvider(_context);

            var userToken = TokenProvider.LoginUser(user.strUsername, user.strPassword);
            if (userToken == null)
            {
                TempData["Err"] = "Wrong password or username";
                return Redirect("~/Home/Index");
                //  return Content(userToken);
            }
            var userIdentity = _context.Users.SingleOrDefault(x => x.strUsername == user.strUsername && x.strPassword == user.strPassword);
            if (userIdentity != null)
            {
                HttpContext.Session.SetString("Name", userIdentity.strName);


                HttpContext.Session.SetString("JWToken", userToken);
              
                if(userIdentity.strRole== "Field Worker")
                {
                    TempData["success"] = "Login Success";
                    return Redirect("~/Home/FieldworkerDashboard");

                }
                else
                {
                    TempData["success"] = "Login Success";
                    return Redirect("~/Home/Dashboard");
                }
                   
            }
            else
            {
                TempData["Err"] = "Wrong password or username";
                return Redirect("~/Home/Index");
            }

        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
