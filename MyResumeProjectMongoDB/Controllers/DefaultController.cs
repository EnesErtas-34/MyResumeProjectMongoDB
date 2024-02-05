using Microsoft.AspNetCore.Mvc;

namespace MyResumeProjectMongoDB.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
