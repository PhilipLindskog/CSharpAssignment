using Business.Factories;
using Business.Interfaces;

namespace Presentation_Console.MainApp.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;


    public void MainMenu()
    {
        var isRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine("---------- CONTACT LIST ----------");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("Q. Exit Application");
            Console.WriteLine("----------------------------------");
            Console.Write("Enter option: ");

            var option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    ShowAddContact();
                    break;

                case "2":
                    ShowAllContacts();
                    break;

                case "q":
                    var answer = QuitApplication();
                    if (answer == true)
                    {
                        isRunning = false;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option. Press any key to try again");
                    Console.ReadKey();
                    break;
            }

        }
        while (isRunning);
    }
    public void ShowAddContact()
    {
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("---------- ADD NEW CONTACT ----------");
        Console.WriteLine("");
        Console.Write("Enter First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter E-mail Address: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter Phone Number: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Enter Street Address: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter Street Code: ");
        contact.Streetcode = Console.ReadLine()!;

        Console.Write("Enter Home City: ");
        contact.City = Console.ReadLine()!;

        _contactService.CreateContact(contact);
    }

    public void ShowAllContacts()
    {
        throw new NotImplementedException();
    }
    public bool QuitApplication()
    {
        Console.Clear();
        Console.WriteLine("---------- EXIT APPLICATION ----------");
        Console.WriteLine("Do you wish to exit the application?");
        Console.Write("Press Y/N:");

        var answer = Console.ReadLine()!;

        if (answer.ToLower() == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
