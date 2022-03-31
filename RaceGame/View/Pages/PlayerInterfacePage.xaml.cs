using System.Windows.Controls;

namespace RaceGame
{

    public partial class PlayerInterfacePage : BasePage, IPageView
    {

        public PlayerInterfacePage(RaceGameRepository repository)
        {
            InitializeComponent();
            this.DataContext = new PlayerInterfaceViewModel(this, repository);
        }



        public override void Navigate(RaceGameRepository repository, string pageName)
        {
            switch (pageName)
            {
                case "Menu":
                    MenuPage menuPage = new MenuPage(repository);
                    this.NavigationService.Navigate(menuPage);
                    break;
                case "Garage":
                    GaragePage garagePage = new GaragePage(repository);
                    this.NavigationService.Navigate(garagePage);
                    break;
                case "Leaderboard":
                    LeaderboardPage leaderboardPage = new LeaderboardPage(repository);
                    this.NavigationService.Navigate(leaderboardPage);
                    break;
            }
        }
        


    }
}
