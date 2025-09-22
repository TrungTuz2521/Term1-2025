using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1.Controllers
{
    
    public class StudentController : Controller
    {
        private static List<Student> listStudent;

        public StudentController()
        {
            // Chỉ khởi tạo 1 lần duy nhất
            if (listStudent == null)
            {
                listStudent = new List<Student>()
        {
            new Student(){ Id=101, Name="Hải Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true, Address = "A1-2018", Email="nam@.com" , Avatar="/images/8b677e0898d2f049210f1bbc8d1a4251.jpg"},
            new Student(){ Id=102, Name="Minh Tú", Branch = Branch.BE, Gender = Gender.Female, IsRegular=true, Address = "A1-2019", Email="tu@.com" , Avatar = "/imagesc55790c064090a0fb9f251c8d3436b74.jpg"},
            new Student(){ Id=103, Name="Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male, IsRegular=false, Address = "A1-2020", Email="phong@.com" ,Avatar = "images/ddcbc56404d0c3f17a25721349618f4c.jpg" },
            new Student(){ Id=104, Name="Xuân Mai", Branch = Branch.EE, Gender = Gender.Female, IsRegular=false, Address = "A1-2021", Email="mai@.com" },
        };
            }
        }
        public IActionResult Index()
        {

            return View(listStudent);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            //Lấy danhh sách các  giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //Lấy danh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị được select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranch = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="IT", Value="1"},
                new SelectListItem(){ Text="BE", Value="2"},
                new SelectListItem(){ Text="CE", Value="3"},
                new SelectListItem(){ Text="EE", Value="4"},
            };
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Student s , IFormFile avatarFile)
        {
            if (avatarFile != null && avatarFile.Length > 0)
            {
                // Lưu ảnh vào thư mục wwwroot/images
                var fileName = Path.GetFileName(avatarFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    avatarFile.CopyTo(stream);
                }

                // Gán đường dẫn cho student
                s.Avatar = "/images/" + fileName;
            }
            s.Id = listStudent.Last<Student>().Id + 1;
            listStudent.Add(s);
            return RedirectToAction("Index");
        }
        public IActionResult Indexxx()
        {
            
            return View();
        }
    }
}
