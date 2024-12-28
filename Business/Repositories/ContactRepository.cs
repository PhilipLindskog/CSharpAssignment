using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Repositories;

public class ContactRepository(IFileService fileService) : IContactRepository
{
    private readonly IFileService _fileService = fileService;

    public List<ContactModel> GetFromFile()
    {
        var json = _fileService.GetContentFromFile();
        if (json != null)
        {
            var list = JsonSerializer.Deserialize<List<ContactModel>>(json);
            return list!;
        }
        else
        {
            return new List<ContactModel>();
        }
    }

    public bool SaveToFile(List<ContactModel> list)
    {
        try
        {
            var json = JsonSerializer.Serialize(list);
            _fileService.SaveContentToFile(json);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
