using ApiConnectionXamarin.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ApiConnectionXamarin.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<string> _outcomes;

        public ObservableCollection<string> Outcomes
        {
            get
            {
                return _outcomes;
            }
            set
            {
                _outcomes = value;
                OnPropertyChanged(nameof(Outcomes));

            }
        }
        public ICommand OutcomeCommand { get; }

        public MainViewModel(IMedicalApiService medicalApiService)
        {
            _medicalApiService = medicalApiService;
            OutcomeCommand = new Command(OnOutcome);
            
        }

        private async void OnOutcome()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var outcomeResponse = await _medicalApiService.GetOutcomesAsync();
                if (outcomeResponse != null)
                {
                    Outcomes = new ObservableCollection<string>(outcomeResponse.Data);
                }
            }
            else 
            {
                MainThread.BeginInvokeOnMainThread(async () => { 
                    await Application.Current.MainPage.DisplayAlert("Alert", "There is not internet connection available. Connection to the api was not possible", "Ok"); 
                });
               
            }

        }

        readonly IMedicalApiService _medicalApiService;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
