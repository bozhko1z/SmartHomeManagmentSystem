using Microsoft.AspNetCore.Mvc;

namespace SmartHomeManagmentSystem.Controllers
{
    public class CustomErrorController : BaseController
    {
        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("404");
                case 500:
                    return View("500");
                default:
                    return View("GenericError");
            }
        }
    }
}
