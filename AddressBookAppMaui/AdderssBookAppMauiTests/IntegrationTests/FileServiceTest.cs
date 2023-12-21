using Xunit;
using Shared.Services;
using Shared.Models;

namespace AdderssBookAppMauiTests.IntegrationTests
{
    public class FileServiceTest
    {
        [Fact]
        public void SaveContentToFile_ShouldSaveContentToFile_ThenReturnTrue()
        {
            //Arrange
            FileService fileService = new FileService(@"B:\C-code\AddressBookAppMaui\contacts.json");
            string content = "UnitTest";

            //Act
            bool result = fileService.SaveContentToFile(content);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteContactFromFile_ShouldDeleteAContactFromList_ThenReturnTrue()
        {
            //Arrange
            FileService fileService = new FileService(@"B:\C-code\AddressBookAppMaui\contacts.json");
            ContactServices contactServices = new ContactServices();    
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", PhoneNumber = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactServices.AddContactToList(contact);

            //Act
            bool result = fileService.DeleteContactFromFile(contact.Email);

            //Assert
            Assert.True(result);
        }

    }
}
