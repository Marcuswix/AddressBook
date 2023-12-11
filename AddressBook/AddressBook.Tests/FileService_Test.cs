using AddressBook.Services;
using AddressBook.Models;
using Moq;
using Xunit;

namespace AddressBook.Tests
{
    public class FileService_Test
    {
        // Detta är integrationstester, då testerna "integrerar" med filsystemet/hårdisken.

        [Fact]
        public void SaveContentToFile_ShouldSaveContentToFile_ThenReturnTrue()
        {
            // Arrange
            FileService fileService = new FileService(@"B:\C-code\AddressBook\contacts.json");
            string content = "Test content";


            // Act
            bool result = fileService.SaveContentToFile(content);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetContentFromFile_ShouldGetContentFromFile_ThenReturnContacts()
        {
            // Arrange
            FileService fileService = new FileService(@"B:\C-code\AddressBook\contacts.json");
            string content = "Test Get Content";
            fileService.SaveContentToFile(content);

            // Act
            string result = fileService.GetContentFromFile();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());

        }

        [Fact]
        public void RemoveContact_ShouldRemoveAContact_ThenReturnTrue()
        {
            // Arrange
            var mockFileService = new Mock<FileService>();
            var contactService = new ContactService();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", Phone = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactService.AddContact(contact);

            // Act
            bool result = contactService.RemoveContact("marcus@marcus.se");

            // Assert
            Assert.True(result);
        }

    }
}
