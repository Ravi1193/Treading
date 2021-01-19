using System.Web.Mvc;

namespace Treading.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }

            return PartialView();
        }
    }
} 