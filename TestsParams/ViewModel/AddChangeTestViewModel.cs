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
        private Tests test;
        private ObservableCollection<Parameters> parametres;
        private Parameters selectedParametr;

        private readonly AddDelegate<Tests> addDelegate;
        private readonly ChangeDelegate changeDelegate;
        private readonly bool isAdd;

        public AddChangeTestViewModel(AddDelegate<Tests> addDelegate)
        {
            isAdd = true;
            test = new Tests();
            test.TestDate = DateTime.Now;
            parametres = new ObservableCollection<Parameters>();
            this.addDelegate = addDelegate;
        }
        public AddChangeTestViewModel(ChangeDelegate changeDelegate, Tests test)
        {
            isAdd = false;
            this.test = test;
            parametres = new ObservableCollection<Parameters>(test.Parameters);
            this.changeDelegate = changeDelegate;
        }

        public DateTime TestDate
        {
            get
            {
                return test.TestDate;
                
            }
            set
            {
                test.TestDate = value;
                OnPropertyChanged();
            }
        }
        public string BlockName
        {
            get
            {
                return test.BlockName;
                
            }
            set
            {
                test.BlockName = value;
                OnPropertyChanged();
            }
        }
        public string Note
        {
            get
            {
                return test.Note;
                
            }
            set
            {
                test.Note = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Parameters> Parametrs
        {
            get
            {
                return parametres;
            }
            set
            {
                parametres = value;
                OnPropertyChanged();
            }
        }
        public Parameters SelectedParameter
        {
            get
            {
                return selectedParametr;
            }
            set
            {
                selectedParametr = value;
                OnPropertyChanged();
            }
        }

        public string ButtonName
        {
            get
            {
                if (isAdd)
                    return "Add Test";
                else
                    return "Save Changes";
            }
        }

        private void AddParametr(Parameters param)
        {
            test.Parameters.Add(param);
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
            Parametrs = new ObservableCollection<Parameters>(test.Parameters);
        }

        private RelayCommand addTestCommand;
        public RelayCommand AddTestCommand
        {
            get
            {
                if (isAdd)
                {
                    return addTestCommand ?? (addTestCommand = new RelayCommand(obj =>
                    {
                        addDelegate(test);
                        ((Window)obj).Close();
                    }));
                }
                else
                {
                    return addTestCommand ?? (addTestCommand = new RelayCommand(obj =>
                    {
                        changeDelegate();
                        ((Window)obj).Close();
                    }));
                }
            }
        }

        private RelayCommand addParameterCommand;
        public RelayCommand AddParameteCommand
        {
            get
            {
                return addParameterCommand ?? (addParameterCommand = new RelayCommand(obj =>
                {
                    AddChangeParametr add = new AddChangeParametr(AddParametr, test.BlockName);
                    add.ShowDialog();
                }));
            }
        }

        private RelayCommand changeParameterCommand;
        public RelayCommand ChangeParameterCommand
        {
            get
            {
                return changeParameterCommand ?? (changeParameterCommand = new RelayCommand(obj =>
                {
                    AddChangeParametr change = new AddChangeParametr(ChangeParameter, SelectedParameter, test.BlockName);
                    change.ShowDialog();
                }));
            }
        }

        private RelayCommand deleteParameterCommand;
        public RelayCommand DeleteParameterCommand
        {
            get
            {
                return deleteParameterCommand ?? (deleteParameterCommand = new RelayCommand(obj =>
                {
                    MessageBoxResult result = MessageBox.Show("Данное действие удалит параметр\n\nвы уверены?", "Удаление параметра", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                        DeleteParameter();
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
