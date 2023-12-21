using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Services;
using Contact = Shared.Models.Contact;

namespace AddressBookMaui.ViewModels
{
    public partial class ContactDetailsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly ContactServices _contactServices;

        public ContactDetailsViewModel(ContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        [ObservableProperty]
        private Contact contact = new();

        [RelayCommand]
        private async Task NavigateToContactList()
        {
            await Shell.Current.GoToAsync("//ContactListPage");
        }

        [RelayCommand]
        private async Task Update(Contact contact)
        {
            _contactServices.UpdateContact(contact);
            Contact = new();
            await Shell.Current.GoToAsync("//ContactListPage");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Contact = (query["Contact"] as Contact)!;
        }
    }
}
