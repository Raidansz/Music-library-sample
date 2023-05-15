
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using ATWSMF_SGUI_2022_23_2.Models;
using ATWSMF_SGUI_2022_23_2.WPFClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ATWSMF_SGUI_2022_23_2.WPFClient
{
    class AlbumsViewModel: ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();
        public ObservableCollection<Album> Albums { get; } = new ObservableCollection<Album>();
        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                SetProperty(ref selectedAlbum, value);
                if (selectedAlbum != null)
                {
                    Name = selectedAlbum.Name;
                }
                (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
                (AddAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand AddAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }

        public AlbumsViewModel()
        {
            DownloadAlbums();




           
            AddAlbumCommand = new RelayCommand(
                 () =>
                 {
                     var n = new Album { Name = Name };
                     _apiClient.PostAsync(n, "http://localhost:4671/api/Album")
                     .ContinueWith((Action<Task>)((task) =>
                     {
                         Application.Current.Dispatcher.Invoke((Action)(() =>
                         {
                             this.Albums.Add(n);
                         }));
                     })); ; 
                 }

                , () => !string.IsNullOrEmpty(Name));


            UpdateAlbumCommand = new RelayCommand(() =>
            {

                SelectedAlbum.Name = Name;
                var temp = SelectedAlbum;
                _apiClient.PutAsync(SelectedAlbum, "http://localhost:4671/api/Album")
                 .ContinueWith((Action<Task>)((task) =>
                 {
                     Application.Current.Dispatcher.Invoke((Action)(() =>
                     {

                         this.Albums.Remove(SelectedAlbum);
                         this.Albums.Add(temp);
                     }));
                 })); ;
            }, () => !string.IsNullOrEmpty(Name));



            DeleteAlbumCommand = new RelayCommand(() =>
            {
                _apiClient.DeleteAsync(SelectedAlbum.Id, "http://localhost:4671/api/Album")
                .ContinueWith((Action<Task>)((task) =>
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        this.Albums.Remove(SelectedAlbum);
                    }));
                }));

            }, () => SelectedAlbum != null);


        }
        private void DownloadAlbums()
        {
            Albums.Clear();
            _apiClient
                .GetAsync<List<Album>>("http://localhost:4671/api/Album")
                .ContinueWith((Action<Task<List<Album>>>)((Albums) =>
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        Albums.Result.ForEach((Action<Album>)(a =>
                        {
                            this.Albums.Add(a);
                        }));

                    }));
                }));



        }

    }
}
