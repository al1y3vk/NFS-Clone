
using System.Windows;
using System.Windows.Controls;


namespace RaceGame
{
    public class BasePage : Page, IPageView
    {
        public virtual void Navigate(RaceGameRepository repository, string pageName) { }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
