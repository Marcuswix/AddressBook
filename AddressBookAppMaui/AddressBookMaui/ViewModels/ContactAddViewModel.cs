using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Services;
using System.Collections.ObjectModel;
using Contact = Shared.Models.Contact;

namespace AddressBookMaui.ViewModels
{
    public partial class ContactAddViewModel : ObservableObject
    {
        private readonly ContactServices _contactServices;

        public ContactAddViewModel(ContactServices contactServices)
        {
            _contactServices = contactServices;
        }


        [ObservableProperty]
        private Contact _contactForm = new();

        [ObservableProperty]
        private ObservableCollection<Contact> _contactList = new ObservableCollection<Contact>();

        [RelayCommand]
        public static async Task NavigateToContactList()
        {
            await Shell.Current.GoToAsync("//ContactListPage");
        }

        [RelayCommand]
        public async void AddContactToList()
        {
            if (ContactForm != null)
            {
                var result = _contactServices.AddContactToList(ContactForm);

                if (result == true)
                {
                    ContactForm = new();
                    await Shell.Current.GoToAsync("//ContactListPage");
                }
                else
                { }
            }
        }
    }
}
