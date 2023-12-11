using AddressBook.Services;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContactService contactService = new ContactService();

            contactService.GetContacts();

            var showMenu = new MenuService();
            
            showMenu.ShowMenu();
        }
    }
}
