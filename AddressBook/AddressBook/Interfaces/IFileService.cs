namespace AddressBook.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// This method fetches a file from the hard drive. If a file exist on the hard drive with the specified filepath, 
        /// it reads the entire file and returns it as a string.    
        /// </summary>
        /// <returns>If successful, it returns the file - if not, it returns null.</returns>
        string GetContentFromFile();

        /// <summary>
        /// This method trys to save the contact information to the hard drive. 
        /// It makes a streamWriter instance to write the content to a file located at the specified filePath.
        /// </summary>
        /// <param name="content"></param>
        /// <returns>It returns true if successful - if not, it returns false.</returns>
        bool SaveContentToFile(string content);

        /// <summary>
        /// This method trys to remove a contact from the contact-list-file that is saved on the hard drive.
        /// It the first fetches and convert the list. It then checks if there is an email adress that matches
        /// with the input parameter. If found, it deletes the contact, if not it returns false. 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>If the contact is removed it returns true - if not, it returns false.</returns>
        bool DeleteContactFromFile(string content);
    }
}