namespace Business.Interfaces;

public interface IFileService
{
    string GetContentFromFile();
    bool SaveContentToFile(string content);
}
