namespace FileServer.Infrastucture.Repository
{
    public interface IFileManager
    {
        void CreateJSONFileIfNonexistent(string path);
        bool JSONFileExists(string path);
        string PathSelector(int comboIndex);
        void WriteToJson(string path, string jsonData);
        string RetrieveJSONData(string path);
    }
}