using LibGit2Sharp;
using System.IO;

namespace MarkDocMVC.Services.FileService {
    public class FileService: IFileService {
        private readonly ILogger<FileService> _logger;
        public FileService(ILogger<FileService> logger) {
            _logger = logger;
        }
        public string ReadFile(string filePath) {
            try {
                var file = System.IO.File.ReadAllText(filePath);
                return file;
            }
            catch (Exception) {
                return null;
            }
        }
        public string CreateFile(string filePath) {
            try {
                System.IO.File.WriteAllText(filePath, "");
                return "Create file on the path: " + filePath;
            }
            catch (Exception) {
                return null;
            }
        }
        public string CreateAndWriteFile(string filePath, string text) {
            try {
                System.IO.File.WriteAllText(filePath, text);
                return "The documentation is updated!";
            }
            catch (Exception) {
                return "Error: Not save file!";
            }
        }
        public string CleanFile(string filePath) {
            try {
                using (var fs = new FileStream(filePath, FileMode.Truncate)) {
                    return "Empty content!\n\nOn the path: " + filePath;
                }
            }
            catch (Exception) {
                return null;
            }
        }
        public string DeleteFile(string filePath) {
            try {
                System.IO.File.Delete(filePath);
                return "My file deleted!\n\nOn the path: " + filePath;
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
