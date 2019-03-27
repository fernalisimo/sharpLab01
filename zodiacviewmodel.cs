using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace _01Kolomeytsev
{
    internal class Zodiacview : INotifyPropertyChanged
    {
        private readonly Model _Model = new Model();
        private RelayCommand<object> _calculateCommand;

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(
                           CalculateImplementation, o => CanExecuteCommand()));
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _Model.Birthday;
            }
            set
            {
                _Model.Birthday = value;
            }
        }

        private bool CanExecuteCommand()
        {
            return _Model.CanCalculate;
        }

        private async void CalculateImplementation(object obj)
        {
            _Model.CanCalculate = false;
            await Task.Run(() => {
                Thread.Sleep(500);
                _Model.CalcZodiaсs();
                if (!_Model.IsValid)
                {
                    MessageBox.Show("Invalid date!", "InvalidDateError", MessageBoxButton.OK);
                }
                else if (_Model.IsBirthday())
                {
                    MessageBox.Show("Happy birthday!");
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Chinese));
                OnPropertyChanged(nameof(Western));
            });
            _Model.CanCalculate = true;
        }


        public string Age
        {
            get
            {
                return $"Your is age:\n{_Model.Age}";
            }
        }

        public string Chinese
        {
            get
            {
                return $"Your chinese zodiac is:\n{_Model.Chinese}";
            }
        }

        public string Western
        {
            get
            {
                return $"Your western zodiac is:\n{_Model.Western}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

