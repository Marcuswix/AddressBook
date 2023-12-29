using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Services;
using System.Collections.ObjectModel;
using Contact = Shared.Models.Contact;

namespace AddressBookMaui.ViewModels
{
    public partial class TheRealContactDetailsViewModel : ObservableObject, IQueryAttributable
    {

        [ObservableProperty]
        private Contact contact = new();

        [ObservableProperty]
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        [RelayCommand]
        private static async Task NavigateToContactList()
        {
            await Shell.Current.GoToAsync("//ContactListPage");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Contact = (query["Contact"] as Contact)!;
        }
    }
}
