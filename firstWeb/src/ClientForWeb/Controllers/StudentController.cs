using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using ViewModels;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientForWeb.Controllers
{

    [Route("[controller]")]
    public class StudentController : Controller
    {
        HttpClient client;

        public StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:6000");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Route("")]
        [Route("[action]")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("/api/Student/").Result;
                string stringdata = response.Content.ReadAsStringAsync().Result; 
                return View(JsonConvert.DeserializeObject<ICollection<StudentBasic>>(stringdata));
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        
        [HttpGet]
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public ActionResult Add(StudentBasic student)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonConvert.SerializeObject(student);
                var contentData = new StringContent(
                    stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("/api/Student/", contentData).Result;
                return Content(response.Content.ReadAsStringAsync().Result.ToString());
            }


            return View();
            
        }

    }
}
