using System.Windows.Controls;


namespace RaceGame
{ 

    public partial class LoadGamePage : BasePage,IPageView
    {

        public LoadGamePage(RaceGameRepository repository)
        {

            InitializeComponent();
            this.DataContext = new LoadGameViewModel(this, repository);
        }

        public override void Navigate(RaceGameRepository repository, string pageName)
        {
            if(pageName == "Menu")
            {
                MenuPage menuPage = new MenuPage(repository);
                this.NavigationService.Navigate(menuPage);
            }
            else if (pageName =="PlayerInterface")
            {
                PlayerInterfacePage playerInterfacePage = new PlayerInterfacePage(repository);
                this.NavigationService.Navigate(playerInterfacePage);
            }
        }
    }
}
