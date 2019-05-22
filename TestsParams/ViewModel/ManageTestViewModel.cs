using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TestsParams.Model;
using TestsParams.MVVM;
using TestsParams.View;

namespace TestsParams.ViewModel
{
    class ManageTestViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Tests> _tests;
        private ObservableCollection<Parameters> _parametrs = new ObservableCollection<Parameters>();
        private Tests _selectedTest;

        public ObservableCollection<Tests> Tests
        {
            get
            {
                return _tests;
            }
            private set
            {
                _tests = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Parameters> Parametrs
        {
            get
            {
                return _parametrs;
            }
            private set
            {
                _parametrs = value;
                OnPropertyChanged();
            }
        }
        public Tests SelectedTest
        {
            get
            {
                return _selectedTest;
            }
            set
            {
                _selectedTest = value;
                if (_selectedTest != null)
                {
                    Parametrs = new ObservableCollection<Parameters>(_selectedTest.Parameters);
                }
                OnPropertyChanged();
            }
        }

        public ManageTestViewModel()
        {
            _tests = new ObservableCollection<Tests>(InsteadDB.GetTests());
        }

        private void AddTest(Tests test)
        {
            InsteadDB.AddTest(test);
            UpdateTests();
        }
        private void ChangeTest()
        {
            UpdateTests();
            UpdateParameters();
        }
        private void DeleteTest()
        {
            InsteadDB.DeleteTest(_selectedTest);
            UpdateTests();
        }

        private void UpdateTests()
        {
            Tests = new ObservableCollection<Tests>(InsteadDB.GetTests());
            InsteadDB.SaveChanges();
        }
        private void UpdateParameters()
        {
            Parametrs = new ObservableCollection<Parameters>(SelectedTest.Parameters);
            InsteadDB.SaveChanges();
        }

        private RelayCommand _addTestCommand;
        public RelayCommand AddTestCommand
        {
            get
            {
                return _addTestCommand ?? (_addTestCommand = new RelayCommand(obj =>
                {
                    AddChangeTest add = new AddChangeTest(AddTest);
                    add.ShowDialog();
                }));
            }
        }

        private RelayCommand _changeTestCommand;
        public RelayCommand ChangeTestCommand
        {
            get
            {
                return _changeTestCommand ?? (_changeTestCommand = new RelayCommand(obj =>
                {
                    if (SelectedTest != null)
                    {
                        AddChangeTest change = new AddChangeTest(ChangeTest, SelectedTest);
                        change.ShowDialog();
                    }
                }));
            }
        }

        private RelayCommand _deleteTestCommand;
        public RelayCommand DeleteTestCommand
        {
            get
            {
                return _deleteTestCommand ?? (_deleteTestCommand = new RelayCommand(obj =>
                {
                    if (SelectedTest != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Данное действие удалит тест\n\nвы уверены?", "Удаление Теста", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                            DeleteTest();
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
