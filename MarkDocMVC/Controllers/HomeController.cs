using MarkDocMVC.Models;
using MarkDocMVC.Services.FileService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarkDocMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileService _fileService ;
        private IWebHostEnvironment Environment;
        public string markdownLabel = "";

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _environment, IFileService fileService)
        {
            _logger = logger;
            Environment = _environment;
            _fileService = fileService; 
        }

        public IActionResult Index() { 
             using (var sr = new StreamReader(Environment.WebRootPath + "/posts/MarkdownTagHelper.md"))
            {
                // Read the stream as a string, and write the string to the console.
                markdownLabel = sr.ReadToEnd();
            }
            //ViewData["marker"] = Parse(markdownLabel);
            ViewData["marker"] = markdownLabel;

            return View();
        }

        [HttpGet]
        public IActionResult ReadFile()
        {
            string result = this._fileService.ReadFile(Environment.WebRootPath + "/posts/MarkdownTagHelper.md");
            return Ok(result);

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
}