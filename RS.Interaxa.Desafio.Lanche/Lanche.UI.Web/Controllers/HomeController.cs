using Lanche.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lanche.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
