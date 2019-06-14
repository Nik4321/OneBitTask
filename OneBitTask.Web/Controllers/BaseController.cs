using Microsoft.AspNetCore.Mvc;

namespace OneBitTask.Web.Controllers
{
    public class BaseController : Controller
    {
        protected void SetSuccessMessage(string message)
        {
            this.TempData["SuccessMessage"] = message;
        }

        protected void SetErrorMessage(string message)
        {
            this.TempData["ErrorMessage"] = message;
        }

        protected void SetWarningMessage(string message)
        {
            this.TempData["WarningMessage"] = message;
        }
    }
}