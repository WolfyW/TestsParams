using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TestsParams.Model;
using TestsParams.MVVM;
using TestsParams.View;

namespace TestsParams.ViewModel
{
    public delegate void AddDelegate<T>(T val);
    public delegate void ChangeDelegate();

    class AddChangeTestViewModel : INotifyPropertyChanged
    {
        private Tests _test;
        private ObservableCollection<Parameters> _parametres;
        private Parameters _selectedParametr;

        private readonly AddDelegate<Tests> _addDelegate;
        private readonly ChangeDelegate _changeDelegate;
        private readonly bool _isAdd;

        public AddChangeTestViewModel(AddDelegate<Tests> addDelegate)
        {
            _isAdd = true;
            _test = new Tests();
            _test.TestDate = DateTime.Now;
            _parametres = new ObservableCollection<Parameters>();
            this._addDelegate = addDelegate;
        }
        public AddChangeTestViewModel(ChangeDelegate changeDelegate, Tests test)
        {
            _isAdd = false;
            this._test = test;
            _parametres = new ObservableCollection<Parameters>(test.Parameters);
            this._changeDelegate = changeDelegate;
        }

        public DateTime TestDate
        {
            get
            {
                return _test.TestDate;
                
            }
            set
            {
                _test.TestDate = value;
                OnPropertyChanged();
            }
        }
        public string BlockName
        {
            get
            {
                return _test.BlockName;
                
            }
            set
            {
                _test.BlockName = value;
                OnPropertyChanged();
            }
        }
        public string Note
        {
            get
            {
                return _test.Note;
                
            }
            set
            {
                _test.Note = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Parameters> Parametrs
        {
            get
            {
                return _parametres;
            }
            set
            {
                _parametres = value;
                OnPropertyChanged();
            }
        }
        public Parameters SelectedParameter
        {
            get
            {
                return _selectedParametr;
            }
            set
            {
                _selectedParametr = value;
                OnPropertyChanged();
            }
        }

        public string ButtonName
        {
            get
            {
                if (_isAdd)
                    return "Add Test";
                else
                    return "Save Changes";
            }
        }

        private void AddParametr(Parameters param)
        {
            _test.Parameters.Add(param);
            UpdateParameters();
        }
        private void DeleteParameter()
        {
            InsteadDB.DeleteParameter(SelectedParameter);
            UpdateParameters();
        }
        private void ChangeParameter()
        {
            UpdateParameters();
        }
        private void UpdateParameters()
        {
            Parametrs = new ObservableCollection<Parameters>(_test.Parameters);
        }

        private RelayCommand _addTestCommand;
        public RelayCommand AddTestCommand
        {
            get
            {
                if (_isAdd)
                {
                    return _addTestCommand ?? (_addTestCommand = new RelayCommand(obj =>
                    {
                        _addDelegate(_test);
                        ((Window)obj).Close();
                    }));
                }
                else
                {
                    return _addTestCommand ?? (_addTestCommand = new RelayCommand(obj =>
                    {
                        _changeDelegate();
                        ((Window)obj).Close();
                    }));
                }
            }
        }

        private RelayCommand _addParameterCommand;
        public RelayCommand AddParameteCommand
        {
            get
            {
                return _addParameterCommand ?? (_addParameterCommand = new RelayCommand(obj =>
                {
                    AddChangeParametr add = new AddChangeParametr(AddParametr, _test.BlockName);
                    add.ShowDialog();
                }));
            }
        }

        private RelayCommand _changeParameterCommand;
        public RelayCommand ChangeParameterCommand
        {
            get
            {
                return _changeParameterCommand ?? (_changeParameterCommand = new RelayCommand(obj =>
                {
                    if (SelectedParameter != null)
                    {
                        AddChangeParametr change = new AddChangeParametr(ChangeParameter, SelectedParameter, _test.BlockName);
                        change.ShowDialog();
                    }
                }));
            }
        }

        private RelayCommand _deleteParameterCommand;
        public RelayCommand DeleteParameterCommand
        {
            get
            {
                return _deleteParameterCommand ?? (_deleteParameterCommand = new RelayCommand(obj =>
                {
                    if (SelectedParameter != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Данное действие удалит параметр\n\nвы уверены?", "Удаление параметра", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                            DeleteParameter();
                    }
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
