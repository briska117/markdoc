using MarkDocMVC.Models;
using MarkDocMVC.Services.FileService;
using MarkDocMVC.Services.GitService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarkDocMVC.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileService _fileService;
        private readonly IGitService gitService;
        private IWebHostEnvironment Environment;
        public string markdownLabel = "";

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _environment, IFileService fileService, IGitService gitService) {
            _logger = logger;
            Environment = _environment;
            _fileService = fileService;
            this.gitService = gitService;
        }

        public IActionResult Index() {
            ViewData["marker"] = this._fileService.ReadFile(Environment.WebRootPath + "/posts/MarkdownTagHelper.md");
            this.gitService.CommitChanges("RocoElWuero", "usuario917@gmail.com"); //

            return View();
        }
        public IActionResult EditDocumentation() {
            ViewData["marker"] = this._fileService.ReadFile(Environment.WebRootPath + "/posts/MarkdownTagHelper.md");

            return View();
        }

        [HttpGet]
        public IActionResult ReadFile() {
            string result = this._fileService.ReadFile(Environment.WebRootPath + "/posts/MarkdownTagHelper.md");
            return Ok(result);

        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveDocumentation([FromBody] DocumentationModel documentContent) {
            string result;
            result = this._fileService.CreateAndWriteFile(Environment.WebRootPath + "/posts/MarkdownTagHelper.md", documentContent.DocumentContent);
            return Ok(result);
        }
    }
}