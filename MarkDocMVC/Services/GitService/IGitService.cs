namespace MarkDocMVC.Services.GitService {
    public interface IGitService {
        public void GetBranches();
        public void GetCommits();
        public void GetCommitById(string commitId);
        public void StageCreatedChanges();
        public void StageChanges();
        public void CommitChanges(string username, string email);
        public void PushChanges();
    }
}
