using System.Windows.Controls;

namespace RaceGame
{
    
    public partial class GaragePage : BasePage, IPageView
    {
        
        public GaragePage(RaceGameRepository repository)
        {
            InitializeComponent();
            this.DataContext = new GarageViewModel(this, repository);
            
        }

        public override void Navigate(RaceGameRepository repository, string pageName)
        {
            if(pageName == "PlayerInterface")
            {
                PlayerInterfacePage playerInterfacePage = new PlayerInterfacePage(repository);
                this.NavigationService.Navigate(playerInterfacePage);
            }
        }
    }
}
