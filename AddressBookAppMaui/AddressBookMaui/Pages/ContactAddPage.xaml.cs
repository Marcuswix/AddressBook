using AddressBookMaui.ViewModels;

namespace AddressBookMaui.Pages;

public partial class ContactAddPage : ContentPage
{
	public ContactAddPage(ContactAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    //private async void BtnToContactList_Clicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("//ContactListPage");
    //}
}