using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Services;
using AddressBookMaui.ViewModels;
using Contact = Shared.Models.Contact;
using System.Diagnostics;

namespace AddressBookMaui.ViewModels
{
    public partial class ContactListViewModel : ObservableObject
    {
        private readonly ContactServices _contactServices;

        [ObservableProperty]
        private ObservableCollection<Contact> _contactList = new ObservableCollection<Contact>();

        [RelayCommand]
        public static async Task NavigateToAddContact()
        {
            await Shell.Current.GoToAsync("//ContactAddPage");
        }

        [RelayCommand]
        public static async Task NavigateToContactDetails(Contact contact)
        {
            var parameters = new ShellNavigationQueryParameters
            {
                { "Contact", contact }
            };

            await Shell.Current.GoToAsync("ContactDetailsPage", parameters);
        }

        [RelayCommand]
        public void RemoveContactFromList(Contact contact)
        {
            if (contact != null)
            {
                var result = _contactServices.RemoveContactFromList(contact);
                if (result)
                {
                    ContactList = new ObservableCollection<Contact>(_contactServices.ShowContacts());
                }
            }
        }

        private bool _contactListEmpty = false;

        public bool ContactListEmpty
        {
            get => _contactListEmpty;
            set => SetProperty(ref _contactListEmpty, value);
        }

        public ContactListViewModel(ContactServices contactServices)
        {

            _contactServices = contactServices;
            ContactList = new ObservableCollection<Contact>(_contactServices.ShowContacts());
            CheckContactList();

            if (ContactList != null)
            {
                contactServices.ContactListUpdated += (sender, e) =>
                {
                    ContactList = new ObservableCollection<Contact>(_contactServices.ShowContacts());
                    CheckContactList();
                };
            }
            else
            {
                CheckContactList();
            }
        }

        private void CheckContactList()
        {
            if (ContactList == null || !ContactList.Any())
            {
                ContactListEmpty = true;
            }
            else
            { 
                ContactListEmpty = false; 
            }
        }
    }
}