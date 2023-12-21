using AddressBook.Models;

namespace AddressBook.Interfaces
{
    public interface IContactService
    {
        /// <summary>
        /// This method adds a contact. It receives a parameter called "contact" of type the "Contact".
        /// It first checks if there already exist another contact with the same email-address. 
        /// If no contact with the same email exists, it adds the contact to the List (_contactList) and then saves it to the hard drive in JSON-format.
        /// </summary>
        /// <param name="contact">A Contact class</param>
        /// <returns>Returns true if successful and false if there already exist a contact with that email.</returns>
        bool AddContact(Contact contact);


        /// <summary>
        /// This Method fetches a file with contacts from the hard drive that is Json-formated. 
        /// It then deserialize the list and add them to the contactList.
        /// If the file is empty or there isn't any file the method returns a empty contactList.
        /// </summary>
        /// <returns>A Contact list with all the saved contacts or an empty Contact list </returns>
        IEnumerable<Contact> GetContacts();


        /// <summary>
        /// This method finds a specific contact in the contactList. It first receives a parameter (a name).
        /// It then fetches all contacts in the contactList
        /// and checks if there are any contacts that match the input parameter (the name).  
        /// </summary>
        /// <param name="name">A string value</param>
        /// <returns>Returns a contact that matches the parameter. If none, it returns null. </returns>
        Contact ShowContact(string name);

        /// <summary>
        /// This method deletes a contact from the contactList. It first receives a parameter (an email address).
        /// It then checks if there is any contact with that email address.
        /// If there is, the method first removes it from contactList and then removes it from the file (stored on the hard drive).
        /// </summary>
        /// <param name="email">A string value</param>
        /// <returns>Returns true if the contact is removed/deleted - otherwise, it returns false.</returns>
        bool RemoveContact(string email);
    }
}