using CommunityToolkit.Mvvm.Input;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATWSMF_SGUI_2022_23_2.WPFClient
{
    internal class MainWindowViewModel
    {
        public ICommand Songs { get; set; }
        public ICommand Artists { get; set; }
        public ICommand Albums { get; set; }





        public MainWindowViewModel()
        {
            Songs = new RelayCommand(() =>
            {
                Songs window = new Songs();
                window.Show();
            });
            Artists = new RelayCommand(() =>
            {
                ArtistsView window = new ArtistsView();
                window.Show();
            });
            Albums = new RelayCommand(() =>
            {
                AlbumsView window = new AlbumsView();
                window.Show();
            });
        }
    }
}
