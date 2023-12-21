namespace Shared.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// This method deletes a contact from a contact-file, that is saved in a Json-format on the hard-drive. It removes them
        /// by finding the email-address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>If successful it returns true, if nor it returns false.</returns>
        bool DeleteContactFromFile(string email);

        /// <summary>
        /// This method gets a file with contacts from the hard-drive. 
        /// </summary>
        /// <returns>It returns the file with the contacts</returns>
        string GetContentFromFile();

        /// <summary>
        /// This method saves the contacts in the list on a file on the hard-drive. 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool SaveContentToFile(string content);
    }
}