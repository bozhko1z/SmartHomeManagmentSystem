using Microsoft.AspNetCore.Mvc;

namespace SmartHomeManagmentSystem.Controllers
{
    public class CustomErrorController : BaseController
    {
        [Route("Error/403")]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
