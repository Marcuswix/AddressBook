using Shared.Models;

namespace Shared.Interfaces
{
    public interface IContactServices
    {
        /// <summary>
        /// Makes a List of the type "Contact".
        /// </summary>
        List<Contact> Contacts { get; }

        /// <summary>
        /// This part update the ContactList.
        /// </summary>
        event EventHandler? ContactListUpdated;

        /// <summary>
        /// This method adds a new contact to the list.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>If succsessful it returns true - if not, ir returns false.</returns>
        bool AddContactToList(Contact contact);

        /// <summary>
        /// This method deletes a contact from the list.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>If succsessful it returns true - if not, ir returns false.</returns>
        bool RemoveContactFromList(Contact contact);

        /// <summary>
        /// This method gets and return the contact list.
        /// </summary>
        /// <returns>ContactList</returns>
        IEnumerable<Contact> ShowContacts();

        /// <summary>
        /// This method overwrite the old contact information.
        /// </summary>
        /// <param name="updatedContact"></param>
        /// <returns>If succsessful it returns true - if not, ir returns false.</returns>
        bool UpdateContact(Contact updatedContact);
    }
}