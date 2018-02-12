using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        static int counter;
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
                "<input type='text' name='name' />" +
                "<select name='language'>" +
                "<option value='english'>English</option>" +
                "<option value='spanish'>Spanish</option>" +
                "<option value='french'>French</option>" +
                "<option value='german'>German</option>" +
                "<option value='italian'>Italian</option>" +
                "</select>" + 
                "<input type='submit' value='Greet Me!'>" +
                "</form>";
            return Content(html, "text/html");
        }

        [Route("/Hello")]
        [HttpPost]
        public IActionResult CreateMessage(string name, string language = "english")
        {
            string greeting = "";
            if (language == "english") greeting = "Hello";
            if (language == "spanish") greeting = "Hola";
            if (language == "french") greeting = "Bonjour";
            if (language == "german") greeting = "Hallo";
            if (language == "italian") greeting = "Ciao";

            string cookie = Request.Cookies[name];
            if (cookie == null)
            {
                Response.Cookies.Append(name, "1");
                counter = 1;
            }
            else
            {
                counter = int.Parse(cookie);
                counter += 1;
                string strCounter = counter.ToString();
                Response.Cookies.Append(name, strCounter);
            }

            return Content(string.Format("<h1>{0} {1}</h1> " +
            "\n<h3>You have visited this page {2} times.", greeting, name, counter), "text/html");
        }

        public IActionResult Display(string name = "World")
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");

        }
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");

        }

        public IActionResult Goodbye()
        {
            return Content("Goodbye!");
        }
    }
}
