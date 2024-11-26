using Microsoft.AspNetCore.Mvc;

namespace SmartHomeManagmentSystem.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidIdValid(string? id, ref Guid parseId)
        {

            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isIdValid = Guid.TryParse(id, out parseId);
            if (!isIdValid)
            {
                return false;
            }

            return true;
        }
    }
}
