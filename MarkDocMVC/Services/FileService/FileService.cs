using LibGit2Sharp;

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
        public void GetBranches() {
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoce")) {
                var branches = repo.Branches;
                foreach (var b in branches) {
                    Console.WriteLine(b.FriendlyName);
                }
            }
        }
        public void GetCommits() {
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoce")) {
                foreach (var commit in repo.Commits) {
                    Console.WriteLine(
                        $"{commit.Id.ToString().Substring(0, 7)} " +
                        $"{commit.Author.When.ToLocalTime()} " +
                        $"{commit.MessageShort} " +
                        $"{commit.Author.Name}");
                }
            }
        }
        public void GetCommitById(string commitId) {
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoce")) {
                foreach (var commit in repo.Commits) {
                    if (commit.Id.ToString() == commitId) {
                        Console.WriteLine(
                            $"{commit.Id.ToString().Substring(0, 7)} " +
                            $"{commit.Author.When.ToLocalTime()} " +
                            $"{commit.MessageShort} " +
                            $"{commit.Author.Name}");
                    }
                }
            }
        }
        public void CommitChanges() {
            
        }
        public void PushChanges() {
            
        }
        public void IGitService () {
            string commitId = "b9f5bdb7ff1fbdf17831b89ba28196ee10482f27";
            //GetBranches();
            //GetCommits();
            GetCommitById(commitId);
            //CommitChanges();
            //PushChanges();
        }

    }
}
