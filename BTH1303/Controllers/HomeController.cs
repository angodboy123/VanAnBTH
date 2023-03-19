using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTH1303.Models;

namespace BTH1303.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    StringProcess str = new StringProcess();
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
      public IActionResult Index(string FullName)
    {
        string lowtoup = str.LowerToUpper(FullName);
        ViewBag.lowtoup = lowtoup;
        string uptolow = str.UpperToLower(FullName);
        ViewBag.uptolow = uptolow;
        // string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower(FullName));
        // ViewBag.ca = titleCase;
        return View();
    }
 
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
