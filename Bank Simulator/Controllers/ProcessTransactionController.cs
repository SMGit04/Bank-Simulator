using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Controllers
{
    public class ProcessTransactionController : Controller
    {
        // This is the "Contract" I sign with the client.

        public IActionResult ProcessTransaction()
        {
            return View();
        }
    }
}
