using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }

        public IActionResult Calculate(Calculator calculator)
        {
            if (calculator.RightOperand == 0)
            {
                return RedirectToAction("Index", calculator);
            }
            calculator.CalculateResult();

            return RedirectToAction("Index", calculator);

        }

    }
}
