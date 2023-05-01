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
        private ApiClient _apiClient = new ApiClient();
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
                (UpdateArtistCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand AddArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }

        public ArtistsViewModel()
        {
            DownloadArtists();




            var n = new Artist { Name = Name };
            AddArtistCommand = new RelayCommand(
                 () =>
                 {
                     _apiClient.PostAsync(n, "http://localhost:4671/api/Artist")
                     .ContinueWith((Action<Task>)((task) =>
                     {
                         Application.Current.Dispatcher.Invoke((Action)(() =>
                         {
                             this.Artists.Add(n);
                         }));
                     })); ; DownloadArtists();
                 }

                , () => !string.IsNullOrEmpty(Name));


            UpdateArtistCommand = new RelayCommand(() =>
            {

                SelectedArtist.Name = Name;
                var temp = SelectedArtist;
                _apiClient.PutAsync(SelectedArtist, "http://localhost:4671/api/Artist")
                 .ContinueWith((Action<Task>)((task) =>
                 {
                     Application.Current.Dispatcher.Invoke((Action)(() =>
                     {

                         this.Artists.Remove(SelectedArtist);
                         this.Artists.Add(temp);
                     }));
                 })); ;
            }, () => !string.IsNullOrEmpty(Name));



            DeleteArtistCommand = new RelayCommand(() =>
            {
                _apiClient.DeleteAsync(SelectedArtist.Id, "http://localhost:4671/api/Artist")
                .ContinueWith((Action<Task>)((task) =>
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        this.Artists.Remove(SelectedArtist);
                    }));
                }));

            }, () => SelectedArtist != null);


        }
        private void DownloadArtists()
        {
            Artists.Clear();
            _apiClient
                .GetAsync<List<Artist>>("http://localhost:4671/api/Artist")
                .ContinueWith((Action<Task<List<Artist>>>)((Artists) =>
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        Artists.Result.ForEach((Action<Artist>)(a =>
                        {
                            this.Artists.Add(a);
                        }));

                    }));
                }));



        }

    }
}
