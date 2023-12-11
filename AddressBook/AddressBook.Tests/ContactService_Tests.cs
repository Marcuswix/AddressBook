using AddressBook.Interfaces;
using AddressBook.Models;
using AddressBook.Services;
using Moq;
using Xunit;

namespace AddressBook.Tests
{
    public class ContactService_Tests
    {
        /// <summary>
        /// Nedan är olika enhetstester som jag har gjort på olika metoder i programmet.
        /// </summary>

        [Fact]
        public void AddToList_AddOneCustomerToList_ThenReturnTrue()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", Phone = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            IContactService contactService = new ContactService();

            // Act
            bool result = contactService.AddContact(contact);

            // Asert
            Assert.True(result);
        }

        [Fact]
        public void GetAllFromList_ShouldGetAllContactsFromList_ThenReturnTrue()
        {
            // Arrange
            ContactService contactService = new ContactService();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", Phone = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactService.AddContact(contact);

            // Act
            IEnumerable<Contact> result = contactService.GetContacts();

            // Assert
            Assert.NotNull(result);
            Assert.True(((IEnumerable<Contact>)result).Any());
        }

        [Fact]
        public void ShowAContact_ShouldReturnAContactThatYouSearchedFor_TheReturnAContact()
        {
            // Arrange
            ContactService contactService = new ContactService();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", Phone = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactService.AddContact(contact);

            // Act
            var result = contactService.ShowContact("Marcus");

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RemoveContact_ShouldRemoveAContact_ThenReturnTrue()
        {
            // Arrange
            ContactService contactService = new ContactService();
            Contact contact = new Contact { FirstName = "Marcus", LastName = "Wickström", Email = "marcus@marcus.se", Phone = "1234567", Address = "Marcusvägen 1", PostalCode = "12345", City = "Halmstad" };
            contactService.AddContact(contact);

            // Act
            bool result = contactService.RemoveContact("marcus@marcus.se");
            
            // Assert
            Assert.True(result);
        }      
    }
}
