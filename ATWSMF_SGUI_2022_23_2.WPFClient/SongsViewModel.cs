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
        private RestService restService;
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

        public SongsViewModel(RestService restService)
        {
            this.restService = restService;
            Songs.Add(new Song { Name = "test " });
            AddSongCommand = new RelayCommand(async () => { await restService.Post(new Song { Name = Name }, "Song"); DownloadSongs(); }, () => !string.IsNullOrEmpty(Name));
            UpdateSongCommand = new RelayCommand(() =>
            {
                Selectedsong.Name = Name;
                restService.Put(Selectedsong, "Song");
            }, () => !string.IsNullOrEmpty(Name));
            DeleteSongCommand = new RelayCommand(() =>
            {
                restService.Delete(Selectedsong.Id, "Song");
                Songs.Remove(Selectedsong);
            }, () => Selectedsong != null);

            DownloadSongs();
        }
        private void DownloadSongs()
        {
            Songs.Clear();
            foreach (var song in restService.Get<Song>("api/Song"))
            {
                Songs.Add(song);
            }
        }
        public SongsViewModel() : this(Ioc.Default.GetService<RestService>())
        {

        }
    }
}
