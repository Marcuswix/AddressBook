using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfAddressBookApp.Mvvm.Models;

namespace WpfAddressBookApp.Mvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private Contact contactForm = new();

        [ObservableProperty]
        private ObservableCollection<Contact> _contactList = new ObservableCollection<Contact>();

        [RelayCommand]
        public void AddContactToList()
        {
            if(!string.IsNullOrEmpty(ContactForm.FirstName) && !string.IsNullOrEmpty(ContactForm.LastName))
            {
                ContactList.Add(ContactForm);
                ContactForm = new();
            }
        }
    }
}
