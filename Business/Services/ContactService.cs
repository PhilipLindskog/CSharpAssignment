using Business.Factories;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;
    private List<ContactModel> _contactList = [];

    public bool CreateContact(ContactModel contact)
    {
        try
        {
            

            if (contact != null )
            {
                contact.Id = IdGenerator.GenerateUniqueId();

                _contactList.Add(contact);
                _contactRepository.SaveToFile(_contactList);

                return true;
            }
            return false;
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<ContactModel> GetContacts()
    {
        _contactList = _contactRepository.GetFromFile();
        if (_contactList != null )
        {
            return _contactList;
        }
        else
        {
            return [];
        }
    }
}
