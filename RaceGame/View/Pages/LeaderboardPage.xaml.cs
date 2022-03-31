
using System.Windows.Controls;

namespace RaceGame
{
   
    public partial class LeaderboardPage : BasePage,IPageView
    {
        

        public LeaderboardPage(RaceGameRepository repository)
        {
           
            InitializeComponent();
            this.DataContext = new LeaderboardViewModel(this, repository);
        }

        public override void Navigate(RaceGameRepository repository, string pageName)
        {
            if (pageName == "PlayerInterface")
            {
                PlayerInterfacePage playerInterfacePage = new PlayerInterfacePage(repository);
                this.NavigationService.Navigate(playerInterfacePage);
            }
        }
    }
}
