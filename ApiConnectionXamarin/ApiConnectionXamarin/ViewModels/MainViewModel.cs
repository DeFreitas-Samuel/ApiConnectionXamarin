using ApiConnectionXamarin.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
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
            var outcomeResponse = await _medicalApiService.GetOutcomesAsync();
            if (outcomeResponse != null)
            {
                Outcomes = new ObservableCollection<string>(outcomeResponse.Data); 
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
