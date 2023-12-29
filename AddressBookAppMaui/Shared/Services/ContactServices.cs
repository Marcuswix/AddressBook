using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class ContactServices : IContactServices
    {
        public List<Contact> Contacts { get; private set; } = [];

        public event EventHandler? ContactListUpdated;

        private readonly FileService _fileService = new FileService(@"B:\C-code\c-sharp\AddressBookAppMaui\contacts.json");

        public bool AddContactToList(Contact contact)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(contact.Email))
                {
                    Contacts.Add(contact);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(Contacts));
                    ContactListUpdated?.Invoke(this, new EventArgs());
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService - AddContactToList" + ex.Message);
                return false;
            }
        }

        public bool UpdateContact(Contact updatedContact)
        {
            try
            {
                var content = _fileService.GetContentFromFile();

                if (!string.IsNullOrEmpty(content))
                {
                    var contacts = JsonConvert.DeserializeObject<List<Contact>>(content);

                    var existingContact = contacts.FirstOrDefault(c => c.Email == updatedContact.Email);

                    if (existingContact != null)
                    {
                        // Update the existing contact with the new data
                        existingContact.FirstName = updatedContact.FirstName;
                        existingContact.LastName = updatedContact.LastName;
                        existingContact.Email = updatedContact.Email;
                        existingContact.PhoneNumber = updatedContact.PhoneNumber;
                        existingContact.Address = updatedContact.Address;
                        existingContact.City = updatedContact.City;
                        existingContact.PostalCode = updatedContact.PostalCode;

                        _fileService.SaveContentToFile(JsonConvert.SerializeObject(contacts));
                        ContactListUpdated?.Invoke(this, new EventArgs());
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService - UpdateContact" + ex.Message);
            }
            return false;
        }

        public bool RemoveContactFromList(Contact contact)
        {
            try
            {
                var existingContact = Contacts.FirstOrDefault(x => x.Email == contact.Email);

                if (existingContact != null)
                {
                    Contacts.Remove(existingContact);
                    _fileService.DeleteContactFromFile(contact.Email);
                    ContactListUpdated?.Invoke(this, EventArgs.Empty);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService - RemoveContactFromList" + ex.Message);
                return false;
            }
        }

        public IEnumerable<Contact> ShowContacts()
        {
            try
            {
                var contentFromFile = _fileService.GetContentFromFile();

                if (!string.IsNullOrEmpty(contentFromFile))
                {
                    Contacts = JsonConvert.DeserializeObject<List<Contact>>(contentFromFile)!;
                }
                return Contacts;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("ContactService - ShowContacts" + ex.Message);
                return null!;
            }
        }
    }
}
