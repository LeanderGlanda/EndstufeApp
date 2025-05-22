using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AudioControl
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _esp32Ip = AppSettings.Esp32Ip;
        public string Esp32Ip
        {
            get => _esp32Ip;
            set
            {
                if (_esp32Ip != value)
                {
                    _esp32Ip = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand => new Command(Save);

        private void Save()
        {
            AppSettings.Esp32Ip = Esp32Ip;
            // Optionally show toast or navigate back
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
