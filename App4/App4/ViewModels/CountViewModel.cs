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
        ICommand _buttonClickComand;
        ICommand _resetClickComand;
        string _countConverted;

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
            get => _countConverted;
            set
            {
                if (string.Equals(_countConverted, value)) return;
                _countConverted = value;
                OnPropertyChanged();
            }
            
        }

        public ICommand ButtonClickComand
        {
            get
            {
                if (_buttonClickComand == null)
                
                    _buttonClickComand = new Command(ButtonClickAction);
                    return _buttonClickComand;
                
            }
        }

        public void ButtonClickAction(object obj)
        {
            Contador++;
        }

        public ICommand ResetClickCommand
        {
            get
            {
                if (_resetClickComand == null)

                    _resetClickComand = new Command(ResetAction);
                return _resetClickComand;

            }
        }

        private void ResetAction()
        {
            Contador = 0;
            CountConverted = "Reinicio completado";
        }
    }
}
