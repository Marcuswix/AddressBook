using AddressBookMaui.ViewModels;

namespace AddressBookMaui.Pages;

public partial class ContactDetailsPage : ContentPage
{
	public ContactDetailsPage(ContactDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}