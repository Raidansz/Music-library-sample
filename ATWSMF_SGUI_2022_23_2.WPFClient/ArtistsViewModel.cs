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
    class ArtistsViewModel : ObservableRecipient
    {
        private RestService restService;
        public ObservableCollection<Artist> Artists { get; } = new ObservableCollection<Artist>();
        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                SetProperty(ref selectedArtist, value);
                if (selectedArtist != null)
                {
                    Name = selectedArtist.Name;
                }
                (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
                (AddArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand AddArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }

        public ArtistsViewModel(RestService restService)
        {
            this.restService = restService;
            Artists.Add(new Artist { Name = "test " });
            AddArtistCommand = new RelayCommand(async () => { await restService.Post(new Artist { Name = Name }, "Artist"); DownloadArtist(); }, () => !string.IsNullOrEmpty(Name));
            UpdateArtistCommand = new RelayCommand(() =>
            {
                SelectedArtist.Name = Name;
                restService.Put(SelectedArtist, "Artist");
            }, () => !string.IsNullOrEmpty(Name));
            DeleteArtistCommand = new RelayCommand(() =>
            {
                restService.Delete(SelectedArtist.Id, "Artist");
                Artists.Remove(SelectedArtist);
            }, () => SelectedArtist != null);

            DownloadArtist();
        }
        private void DownloadArtist()
        {
            Artists.Clear();
            foreach (var artist in restService.Get<Artist>("api/Artist"))
            {
                Artists.Add(artist);
            }
        }
        public ArtistsViewModel() : this(Ioc.Default.GetService<RestService>())
        {

        }
    }
}
