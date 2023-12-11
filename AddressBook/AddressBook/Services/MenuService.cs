using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Services
{
    public class MenuService : IMenuService
    {
        public ContactService _contactService = new ContactService();

        private readonly List<IContact> _contact = new List<IContact>();

        bool end = true;

        public void ShowMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("### Main Menu ###");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show all Contacts (Overview)");
                Console.WriteLine("3. Show A Specific Contact (Detalied view)");
                Console.WriteLine("4. Remove A Contact");
                Console.WriteLine("5. Quit program");
                Console.Write("\nYour chocie: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAddContact();
                        break;
                    case "2":
                        ShowAllContacts();
                        break;
                    case "3":
                        ShowAContact();
                        break;
                    case "4":
                        RemoveContact();
                        break;
                    case "5":
                        AreYouShure();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (end);
        }

        private void ShowAddContact()
        {
            Contact contact = new Contact();

            MenuTitle("Add Contact");
            Console.Write("First Name: ");
            var FirstName = Console.ReadLine() ?? string.Empty;
            contact.FirstName = FormattedName(FirstName);
            Console.Write("\nLast Name: ");
            var LastName = Console.ReadLine() ?? string.Empty;
            contact.LastName = FormattedName(LastName);
            Console.Write("\nEmail: ");
            contact.Email = Console.ReadLine()!.Trim() ?? string.Empty;
            Console.Write("\nPhone-number: ");
            contact.Phone = Console.ReadLine() ?? string.Empty;
            Console.Write("\nCity: ");
            var city = Console.ReadLine() ?? string.Empty;
            contact.City = FormattedName(city);
            Console.Write("\nAdress:");
            contact.Address = Console.ReadLine() ?? string.Empty;
            Console.Write("\nPostal Code: ");
            contact.PostalCode = Console.ReadLine() ?? string.Empty;

            bool contactAdded = _contactService.AddContact(contact);

            if (contactAdded == true)
            {
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("\nContact was added successfully!");
            }
            else
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------------");
                Console.WriteLine("\nA contact with the same email already exists or you haven't entered an email address.");
            }
            PressAnyKey();
        }

        private void ShowAllContacts()
        {
            var contact = _contactService.GetContacts();

            MenuTitle("Contacts");
            if (contact != null)
            {
                foreach (var c in contact)
                {
                    Console.WriteLine($"Name: {c.FirstName} {c.LastName}\nEmail: {c.Email}");
                    Console.WriteLine("\n------------------------\n");
                }
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("There are no contacts in your adress book.");
                PressAnyKey();
            }
        }

        public void ShowAContact()
        {
            MenuTitle("Contact Details");

            Console.Write("Search for a contact by name: ");

            var searchUnFormate = Console.ReadLine() ?? string.Empty;

            var search = searchUnFormate.Substring(0, 1).ToUpper() + searchUnFormate.Substring(1).ToLower();

            var contact = _contactService.ShowContact(search);

            if (contact != null)
            {
                Console.Clear();
                MenuTitle("Contact Details");
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}\nEmail: {contact.Email}\nPhone-number: {contact.Phone}\nAddress: {contact.Address}\nPostal Code: {contact.PostalCode}\nCity: {contact.City}\n");
            }
            else
            {
                Console.WriteLine("There is no contact by that name...");
            }
            PressAnyKey();
        }

        private void RemoveContact()
        {

            MenuTitle("Delete contact");
            Console.Write("Write the email-address of the contact you wish to delete (if you want to go back press 'q' and enter): \n\n");
            var removeContact = Console.ReadLine();

            if (!string.IsNullOrEmpty(removeContact) && removeContact != "q")
            {
                var remove = _contactService.RemoveContact(removeContact);

                if (remove == true)
                {
                    bool yesNo = AreYouShureDelete();

                    if (yesNo == true)
                    {
                        Console.WriteLine("\nContact is successfully removed/deleted");
                        PressAnyKey();
                    }
                }
                else if (remove == false)
                {
                    Console.WriteLine("\nThere is no contact with that email...");
                    PressAnyKey();
                }
                else
                {
                    Console.WriteLine("\nSomething went seriously wrong!");
                    PressAnyKey();
                }
            }
            if (removeContact == "q")
            {

            }
        }

        public void AreYouShure()
        {
            bool quit = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Are you shure you want to quit? (y/n): ");
                var areYouShure = Console.ReadLine()!.Trim().ToLower() ?? string.Empty;
                switch (areYouShure)
                {
                    case "y":
                        Console.Clear();
                        Console.WriteLine("See you another time!");
                        Thread.Sleep(1000);
                        quit = false;
                        end = false;
                        break;
                    case "n":
                        quit = false;
                        break;
                    default:
                        Console.Write("\nNot a valid option");
                        Thread.Sleep(1000);
                        break;
                }
            } while (quit);

        }

        public void MenuTitle(string title)
        {
            Console.Clear();
            Console.WriteLine($"### {title} ###");
            Console.WriteLine("------------------------\n");
        }

        public void PressAnyKey()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        public string FormattedName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            string trimedName = name.Trim();
            string formattedName = trimedName.Substring(0, 1).ToUpper() + trimedName.Substring(1).ToLower();
            return formattedName;
        }

        public bool AreYouShureDelete()
        {
            Console.Write("\nAre you shure you want to delete this contact? (y/n): ");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    Console.WriteLine("Not av valid option");
                    PressAnyKey();
                    return false;
            }
        }
    }
}
