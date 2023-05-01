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
    class SongsViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();
        public ObservableCollection<Song> Songs { get; } = new ObservableCollection<Song>();
        private Song selectedSong;

        public Song Selectedsong
        {
            get { return selectedSong; }
            set
            {
                SetProperty(ref selectedSong, value);
                if (selectedSong != null)
                {
                    Name = selectedSong.Name;
                }
                (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
                (AddSongCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateSongCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand AddSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }

        public SongsViewModel()
        {
            DownloadSongs();


       

            var n = new Song { Name = Name };
            AddSongCommand = new RelayCommand(
                 () => 
                { _apiClient.PostAsync(n, "http://localhost:4671/api/Song")
                    .ContinueWith((task) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Songs.Add(n);
                        });
                    }); ; DownloadSongs(); }
                
                , () => !string.IsNullOrEmpty(Name));


            UpdateSongCommand = new RelayCommand(() =>
            {

                Selectedsong.Name = Name;
                var temp = Selectedsong;
                _apiClient.PutAsync(Selectedsong, "http://localhost:4671/api/Song")
                 .ContinueWith((task) =>
                 {
                     Application.Current.Dispatcher.Invoke(() =>
                     {
                       
                         Songs.Remove(Selectedsong);
                         Songs.Add(temp);
                     });
                 }); ;
            }, () => !string.IsNullOrEmpty(Name));



            DeleteSongCommand = new RelayCommand(() =>
            {
                _apiClient.DeleteAsync(Selectedsong.Id, "http://localhost:4671/api/Song")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Songs.Remove(Selectedsong);
                    });
                });
               
            }, () => Selectedsong != null);

         
        }
        private void DownloadSongs()
        {
            Songs.Clear();
            _apiClient
                .GetAsync<List<Song>>("http://localhost:4671/api/Song")
                .ContinueWith((songs) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        songs.Result.ForEach(song =>
                        {
                            Songs.Add(song);
                        });
                       
                    });
                });


           
        }
        
    }
}
