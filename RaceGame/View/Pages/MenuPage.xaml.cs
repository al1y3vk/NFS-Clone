using System.Windows;
using System.Windows.Controls;

namespace RaceGame
{
    
    public partial class MenuPage : BasePage, IPageView
    {
        public MenuPage()
        {
            InitializeComponent();
            this.DataContext = new MenuViewModel(this);
        }
        public MenuPage(RaceGameRepository repository)
        {
            InitializeComponent();
            this.DataContext = new MenuViewModel(this, repository);
        }

        private void Exitbutton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            main.Close();
        }


        public override void Navigate(RaceGameRepository repository, string pageName)
        {
            if (pageName == "LoadMenu")
            {
                LoadGamePage loadGamePage = new LoadGamePage(repository);
                this.NavigationService.Navigate(loadGamePage);
            }
            else if (pageName == "PlayerCreation")
            {
                PlayerCreationPage playerPage = new PlayerCreationPage(repository);
                this.NavigationService.Navigate(playerPage);
            }
        }
    }
}
