using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


using TestsParams.Model;
using TestsParams.MVVM;

namespace TestsParams.ViewModel
{
    public delegate void AddDelegate<T>(T val);
    public delegate void ChangeDelegate();


    class AddChangeTestViewModel : INotifyPropertyChanged
    {
        private Tests test;
        private ObservableCollection<Parameters> parametres;

        private readonly AddDelegate<Tests> add;
        private readonly ChangeDelegate change;
        private bool isAdd;

        public AddChangeTestViewModel(AddDelegate<Tests> addDelegate)
        {
            isAdd = true;
            test = new Tests();
            test.TestDate = DateTime.Now;
            parametres = new ObservableCollection<Parameters>();
            add = addDelegate;
        }
        public AddChangeTestViewModel(ChangeDelegate changeDelegate, Tests test)
        {
            isAdd = false;
            this.test = test;
            parametres = new ObservableCollection<Parameters>(InsteadDB.GetParametrs(this.test));
            change = changeDelegate;
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

        private RelayCommand addTestCommand;
        public RelayCommand AddTestCommand
        {
            get
            {
                if (isAdd)
                {
                    return addTestCommand ?? (addTestCommand = new RelayCommand(obj =>
                    {
                        add(test);
                        ((Window)obj).Close();
                    }));
                }
                else
                {
                    return addTestCommand ?? (addTestCommand = new RelayCommand(obj =>
                    {
                        change();
                        ((Window)obj).Close();
                    }));
                }
            }
        }

        private RelayCommand addParamCommand;
        public RelayCommand AddParamCommand
        {
            get
            {
                return addParamCommand ?? (addParamCommand = new RelayCommand(obj =>
                {
                    
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
