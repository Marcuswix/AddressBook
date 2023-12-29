using AddressBookMaui.ViewModels;

namespace AddressBookMaui.Pages;

public partial class TheRealContactDetailsPage : ContentPage
{
	public TheRealContactDetailsPage(TheRealContactDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}