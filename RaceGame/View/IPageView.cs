using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork5.RaceModel;
namespace RaceGame
{
    public interface IPageView
    {
        void Navigate(RaceGameRepository repository, string pageName);
        void ShowMessage(string message);
    }
}
