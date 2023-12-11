namespace AddressBook.Interfaces
{
    public interface IMenuService
    {
        void AreYouShure();
        bool AreYouShureDelete();
        string FormattedName(string name);
        void MenuTitle(string title);
        void PressAnyKey();

        /// <summary>
        /// This method shows a specific contact.
        /// </summary>
        void ShowAContact();

        /// <summary>
        /// This method shows the main menu.
        /// </summary>
        void ShowMenu();
    }
}