using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Controllers
{
    public class ProcessTransactionController : Controller
    {
        public IActionResult ProcessTransaction()
        {
            return View();
        }
    }
}
