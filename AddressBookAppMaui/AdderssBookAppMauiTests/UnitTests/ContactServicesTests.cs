using Shared.Models;
using Shared.Services;
using Xunit;

namespace AdderssBookAppMauiTests.UnitTests
{
    public class ContactServicesTests
    {
        [Fact]
        public void RemoveContactFromList_ShouldDeleteAContactByEmail_ThenReturnTrue()
        {
            //Arrange
            ContactServices contactServices = new ContactServices();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", PhoneNumber = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactServices.AddContactToList(contact);

            //Act
            bool result = contactServices.RemoveContactFromList(contact);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ShowContacts_ShouldShowAllContacts_AndReturnAllContacts()
        {
            //Arrange
            ContactServices contactServices = new ContactServices();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", PhoneNumber = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactServices.AddContactToList(contact);

            //Act
            contactServices.ShowContacts();

            //Assert
            Assert.Contains("Marcus", contact.FirstName);
            Assert.Contains("Wickström", contact.LastName);
            Assert.Contains("marcus@marcus.se", contact.Email);
        }
    }
}
