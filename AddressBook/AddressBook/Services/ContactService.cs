using AddressBook.Interfaces;
using AddressBook.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AddressBook.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> _contactList = new List<Contact>();

        private readonly FileService _fileService = new FileService(@"B:\C-code\AddressBook\contacts.json");

        public bool AddContact(Contact contact)
        {
            try
            {
                if (!_contactList.Any(x => x.Email == contact.Email) && contact.Email != null)
                {
                    _contactList.Add(contact);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
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

        public IEnumerable<Contact> GetContacts()
        {
            try
            {
                var content = _fileService.GetContentFromFile();

                if (!string.IsNullOrEmpty(content))
                {
                    _contactList = JsonConvert.DeserializeObject<List<Contact>>(content)!;
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return _contactList;
        }

        public Contact ShowContact(string name)
        {
            try
            {
                var contact = GetContacts();

                foreach (var c in contact)
                {
                    if (c.FirstName == name)
                    {
                        return c;
                    }

                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public bool RemoveContact(string email)
        {
            try
            {
                var contactToRemove = _contactList.FirstOrDefault(c => c.Email == email);

                if (contactToRemove != null)
                {
                    _contactList.Remove(contactToRemove);
                    _fileService.DeleteContactFromFile(email);
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

    }
}
