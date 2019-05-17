using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestsParams.Model;
using TestsParams.MVVM;
using TestsParams.View;

namespace TestsParams.ViewModel
{
    class ManageTestViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Tests> tests;
        private ObservableCollection<Parameters> parametrs = new ObservableCollection<Parameters>();
        private Tests selectedItem;

        public ObservableCollection<Tests> Tests
        {
            get
            {
                return tests;
            }
            private set
            {
                tests = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Parameters> Parametrs
        {
            get
            {
                return parametrs;
            }
            private set
            {
                parametrs = value;
                OnPropertyChanged();
            }
        }

        public Tests SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    Console.WriteLine(selectedItem.BlockName);
                    Parametrs = new ObservableCollection<Parameters>(InsteadDB.GetParametrs(selectedItem));
                }
                OnPropertyChanged();
            }
        }

        public ManageTestViewModel()
        {
            tests = new ObservableCollection<Tests>(InsteadDB.GetTests());
        }

        private void AddTest(Tests test)
        {
            InsteadDB.AddTest(test);
            UpdateTests();
        }

        private void ChangeTest()
        {
            UpdateTests();
        }

        private void DeleteTest()
        {
            InsteadDB.DeleteTest(selectedItem);
            UpdateTests();
        }

        private void UpdateTests()
        {
            Tests = new ObservableCollection<Tests>(InsteadDB.GetTests());
        }

        private RelayCommand addTestCommand;
        public RelayCommand AddTestCommand
        {
            get
            {
                return addTestCommand ?? (addTestCommand = new RelayCommand(obj =>
                {
                    AddChangeTest add = new AddChangeTest(AddTest);
                    add.ShowDialog();
                }));
            }
        }

        private RelayCommand changeTestCommand;
        public RelayCommand ChangeTestCommand
        {
            get
            {
                return changeTestCommand ?? (changeTestCommand = new RelayCommand(obj =>
                {
                    AddChangeTest change = new AddChangeTest(ChangeTest, SelectedItem);
                    change.ShowDialog();
                }));
            }
        }

        private RelayCommand deleteTestCommand;
        public RelayCommand DeleteTestCommand
        {
            get
            {
                return deleteTestCommand ?? (deleteTestCommand = new RelayCommand(obj =>
                {
                    DeleteTest();
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
