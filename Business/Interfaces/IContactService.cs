using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    bool CreateContact(ContactModel contact);
    IEnumerable<ContactModel> GetContacts();
}
