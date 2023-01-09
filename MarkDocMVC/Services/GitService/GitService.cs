using LibGit2Sharp;

namespace MarkDocMVC.Services.GitService {
    public class GitService : IGitService {
        public void GetBranches() {
            //var AppName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["APP_Name"];
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoc")) {
                var branches = repo.Branches;
                foreach (var b in branches)
                {
                    Console.WriteLine(b.FriendlyName);
                }
            }
        }
        public void GetCommits() {
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoc")) {
                foreach (var commit in repo.Commits) {
                    Console.WriteLine(
                        $"Commit Full ID: {commit.Id.ToString().Substring(0, 7)} " +
                        $"Time: {commit.Author.When.ToLocalTime()} " +
                        $"Message: {commit.MessageShort} " +
                        $"Author: {commit.Author.Name}");
                }
            }
        }
        public void GetCommitById(string commitId) { //b9f5bdb7ff1fbdf17831b89ba28196ee10482f27 
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoc")) {
                //repo.Branches.Where(c => c.FriendlyName)
                var commit = repo.Commits.Where(c => c.Id.ToString() == commitId).FirstOrDefault();
                Console.WriteLine(
                    $"Commit Full ID: {commit.Id.ToString().Substring(0, 7)} " +
                    $"Time: {commit.Author.When.ToLocalTime()} " +
                    $"Message: {commit.MessageShort} " +
                    $"Author: {commit.Author.Name}");
            }
        }
        public void StageChanges() {
            try {
                using (var repo = new Repository(@"c:\users\oscar\projects\markdoc")) {
                    RepositoryStatus status = repo.RetrieveStatus();
                    List<string> filePaths = status.Modified.Select(mods => mods.FilePath).ToList();
                    foreach (var filePath in filePaths) {
                        repo.Index.Add(filePath); repo.Index.Write();
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Exception:RepoActions:StageChanges " + ex.Message);
            }
        }
        public void StageCreatedChanges() {
            try {
                using (var repo = new Repository(@"c:\users\oscar\projects\markdoc")) {
                    RepositoryStatus status = repo.RetrieveStatus();
                    List<string> filePaths = status.Added.Select(mods => mods.FilePath).ToList();
                    foreach (var filePath in filePaths) {
                        repo.Index.Add(filePath); repo.Index.Write();
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Exception:RepoActions:StageChanges " + ex.Message);
            }
        }

        public void CommitChanges(string username, string email) {
            try {
                StageCreatedChanges();
                StageChanges();
                using (var repo = new Repository(@"c:\users\oscar\projects\markdoc")) {
                    repo.Commit("Updating files..", new Signature(username, email, DateTimeOffset.Now),
                    new Signature(username, email, DateTimeOffset.Now));
                }
            }
            catch (Exception e) {
                Console.WriteLine("Exception:RepoActions:CommitChanges " + e.Message);
            }
        }
        public void PushChanges() {
            using (var repo = new Repository(@"C:\Users\oscar\Projects\markdoc")) {
                //repo.
                //Git git = new Git(new FileRepository(@"C:\Users\oscar\Projects\markdoc"));
            }
        }
    }
}
