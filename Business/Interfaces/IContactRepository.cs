using Business.Models;

namespace Business.Interfaces;

public interface IContactRepository
{
    public List<ContactModel> GetFromFile();
    public bool SaveToFile(List<ContactModel> list);

}
