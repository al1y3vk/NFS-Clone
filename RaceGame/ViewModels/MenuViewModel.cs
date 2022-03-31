
namespace RaceGame
{
    public class MenuViewModel
    {
        IPageView View;
        public RaceGameRepository Repository;

        private RelayCommand toLoadGameCommand;
        private RelayCommand toPlayerCreationCommand;

        public MenuViewModel(IPageView view)
        {
            this.View = view;
            Repository = new RaceGameRepository();
        }

        public MenuViewModel(IPageView view, RaceGameRepository repository)
        {
            this.View = view;
            this.Repository = repository;
        }

        public RelayCommand ToLoadGameCommand
        {
            get
            {
                if (toLoadGameCommand is null)
                {
                    return toLoadGameCommand = new RelayCommand
                    (
                        (param) =>
                        {
                            View.Navigate(Repository, "LoadMenu");
                        }
                        );
                }
                return toLoadGameCommand;
            }
        }

        public RelayCommand ToPlayerCreationCommand
        {
            get
            {
                if (toPlayerCreationCommand is null)
                {
                    return toPlayerCreationCommand = new RelayCommand
                    (
                        (param) =>
                        {
                            View.Navigate(Repository, "PlayerCreation");
                        }
                        );
                }
                return toPlayerCreationCommand;
            }
        }
    }
}
