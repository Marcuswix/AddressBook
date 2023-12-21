namespace Shared.Interfaces
{
    public interface IContact
    {
        /// <summary>
        /// This inteface definies a "contract" for the properties of a contact.  
        /// </summary>
        string Address { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        Guid Id { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string PostalCode { get; set; }
    }
}