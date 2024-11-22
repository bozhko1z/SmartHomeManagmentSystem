using Microsoft.AspNetCore.Mvc;

namespace SmartHomeManagmentSystem.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidIdValid(string? id, ref Guid roomId)
        {

            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isIdValid = Guid.TryParse(id, out roomId);
            if (!isIdValid)
            {
                return false;
            }

            return true;
        }
    }
}
