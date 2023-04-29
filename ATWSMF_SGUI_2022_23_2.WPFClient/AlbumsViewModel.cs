
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
    class AlbumsViewModel : ObservableRecipient
    {
        private RestService restService;
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
                (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand AddAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }

        public AlbumsViewModel(RestService restService)
        {
            this.restService = restService;
            Albums.Add(new Album { Name = "test " });
            AddAlbumCommand = new RelayCommand(async () => { await restService.Post(new Album { Name = Name }, "Album"); DownloadAlbums(); }, () => !string.IsNullOrEmpty(Name));
            UpdateAlbumCommand = new RelayCommand(() =>
            {
                SelectedAlbum.Name = Name;
                restService.Put(SelectedAlbum, "Song");
            }, () => !string.IsNullOrEmpty(Name));
            DeleteAlbumCommand = new RelayCommand(() =>
            {
                restService.Delete(SelectedAlbum.Id, "Song");
                Albums.Remove(SelectedAlbum);
            }, () => SelectedAlbum != null);

            DownloadAlbums();
        }
        private void DownloadAlbums()
        {
            Albums.Clear();
            foreach (var album in restService.Get<Album>("api/Song"))
            {
                Albums.Add(album);
            }
        }
        public AlbumsViewModel() : this(Ioc.Default.GetService<RestService>())
        {

        }
    }
}
