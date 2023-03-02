using Microsoft.AspNetCore.Mvc;

namespace MusicOrganizer.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Letter() 
    {
      return View();
    }
  }
}