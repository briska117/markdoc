namespace MarkDocMVC.Services.FileService {
    public interface IFileService {
        public string ReadFile(string filePath);
        public string CreateFile(string filePath);
        public string CreateAndWriteFile(string filePath, string text);
        public string CleanFile(string filePath);
        public string DeleteFile(string filePath);
    }
}
