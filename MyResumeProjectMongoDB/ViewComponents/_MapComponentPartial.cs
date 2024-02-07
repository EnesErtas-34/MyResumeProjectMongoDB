using Microsoft.AspNetCore.Mvc;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _MapComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
