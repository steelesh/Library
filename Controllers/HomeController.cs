using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IT3047C_FinalProj.Models;

namespace IT3047C_FinalProj.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private BookContext context { get; set; }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}

