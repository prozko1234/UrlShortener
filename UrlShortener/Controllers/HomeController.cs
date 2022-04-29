using Application.Dtos;
using Application.Services.Links;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinkService _linkService;

        public HomeController(ILogger<HomeController> logger, ILinkService linkService)
        {
            _logger = logger;
            _linkService = linkService;
        }

        public IActionResult Index()
        {
            var links = _linkService.GetAll();
            return View(links);
        }
        
        [HttpGet]
        public IActionResult Generate()
        {
            return View(new LinkDto());
        }

        [HttpPost]
        public IActionResult Generate(LinkDto link)
        {
            var request = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            _linkService.Generate(link, request);
            return RedirectToAction("Index");
        }

        [HttpGet("/short/{code}")]
        public IActionResult Shortener(string code)
        {
            var link = _linkService.GetByCode(code);
            return Redirect(link.Url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}