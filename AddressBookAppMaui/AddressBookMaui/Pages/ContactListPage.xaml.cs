using AddressBookMaui.ViewModels;
using CommunityToolkit.Mvvm.Collections;
using System.Collections.ObjectModel;

namespace AddressBookMaui.Pages;


public partial class ContactListPage : ContentPage
{
	public ContactListPage(ContactListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}