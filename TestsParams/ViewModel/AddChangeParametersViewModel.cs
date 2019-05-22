using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TestsParams.Model;
using TestsParams.MVVM;

namespace TestsParams.ViewModel
{
    class AddChangeParametersViewModel : INotifyPropertyChanged
    {
        private readonly Parameters _param;
        private readonly bool _isAdd;

        public AddChangeParametersViewModel(ChangeDelegate changeDelegate, Parameters param, string testName)
        {
            _isAdd = false;
            this._param = param;
            this.TestName = testName;
            this._changeDelegate = changeDelegate;
        }
        public AddChangeParametersViewModel(AddDelegate<Parameters> addDelegate, string testName)
        {
            _isAdd = true;
            _param = new Parameters();
            this.TestName = testName;
            this._addDelegate = addDelegate;
        }

        public string TestName { get; }

        private readonly ChangeDelegate _changeDelegate;
        private readonly AddDelegate<Parameters> _addDelegate;

        public string ParameterName
        {
            get
            {
                return _param.ParameterName;
            }
            set
            {
                _param.ParameterName = value;
                OnPropertyChanged();
            }
        }
        public decimal RequiredValue
        {
            get
            {
                return _param.RequiredValue;
            }
            set
            {
                _param.RequiredValue = value;
                OnPropertyChanged();
            }
        }
        public decimal MeasuredValue
        {
            get
            {
                return _param.MeasuredValue;
            }
            set
            {
                _param.MeasuredValue = value;
                OnPropertyChanged();
            }
        }
        public string ButtonName
        {
            get
            {
                if (_isAdd)
                    return "Add Parametr";
                else
                    return "Save Changes";
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (_isAdd)
                {
                    return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                    {
                        _addDelegate(_param);
                        ((Window)obj).Close();
                    }));
                }
                else
                {
                    return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                    {
                        _changeDelegate();
                        ((Window)obj).Close();
                    }));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
