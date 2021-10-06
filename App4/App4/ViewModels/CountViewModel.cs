using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class CountViewModel : BaseViewModel
    {
        int _contador;
        ICommand _buttonClickCommand;
        ICommand _resetClickCommand;
        string _countCorverted;
        public CountViewModel()
        {
            _contador = 0;
        }

        public int Contador 
        { 
            get => _contador;
            set 
            {
                if (value == _contador) return;
                _contador = value;
                CountConverted = $"Has dado click {_contador} veces";
                OnPropertyChanged();
            }
        }

        public string CountConverted
        {
            get => _countCorverted;
            set
            {
                if (string.Equals(_countCorverted, value)) return;
                _countCorverted = value;
                OnPropertyChanged();
            }
        }


        public ICommand ButtonClickCommand
        {
            get
            { 
                if(_buttonClickCommand == null) 
                
                _buttonClickCommand = new Command(ButtonClickAction);
                return _buttonClickCommand;
            }
        }

        public ICommand ResetClickCommand
        {
            get
            {
                if (_resetClickCommand == null)

                    _resetClickCommand = new Command(ResetAction);
                return _resetClickCommand;
            }
        }

        private void ResetAction()
        {
            Contador = 0;
            CountConverted = "Has resetado esta";
        }

        private void ButtonClickAction()
        {
            Contador++;
        }
    }
}
