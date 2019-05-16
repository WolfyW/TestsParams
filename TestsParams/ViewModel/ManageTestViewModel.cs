using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestsParams.Model;

namespace TestsParams.ViewModel
{
    class ManageTestViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Tests> tests = new ObservableCollection<Tests>();
        ObservableCollection<Parameters> parametrs = new ObservableCollection<Parameters>();
        Tests selectedItem;

        public ObservableCollection<Tests> Tests
        {
            get
            {
                return tests;
            }
            private set
            {
                Tests = value;
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
                Console.WriteLine(selectedItem.BlockName);
                var pars = from p in par
                           where p.TestId == selectedItem.TestId
                           select p;
                Parametrs = new ObservableCollection<Parameters>(pars.ToList());
                OnPropertyChanged();
            }
        }

        public ManageTestViewModel()
        {
            tests = new ObservableCollection<Tests>(tes);
        }

        List<Tests> tes = new List<Tests>()
        {
            new Tests() { TestId = 0, BlockName = "Тест №0", Note = "это тест номер №0", TestDate = DateTime.Now },
            new Tests() { TestId = 1, BlockName = "Тест №1", Note = "это тест номер №1", TestDate = DateTime.Now },
            new Tests() { TestId = 2, BlockName = "Тест №2", Note = "это тест номер №2", TestDate = DateTime.Now },
            new Tests() { TestId = 3, BlockName = "Тест №3", Note = "это тест номер №3", TestDate = DateTime.Now },
            new Tests() { TestId = 4, BlockName = "Тест №4", Note = "это тест номер №4", TestDate = DateTime.Now }
        };

        List<Parameters> par = new List<Parameters>()
        {
            new Parameters() { TestId = 0, ParametrId = 0,  ParameterName = "Параметра №0",  MeasuredValue = 0,  RequiredValue = 0, },
            new Parameters() { TestId = 0, ParametrId = 1,  ParameterName = "Параметра №1",  MeasuredValue = 10, RequiredValue = 10 },
            new Parameters() { TestId = 0, ParametrId = 2,  ParameterName = "Параметра №2",  MeasuredValue = 20, RequiredValue = 20 },
            new Parameters() { TestId = 1, ParametrId = 3,  ParameterName = "Параметра №3",  MeasuredValue = 30, RequiredValue = 30 },
            new Parameters() { TestId = 1, ParametrId = 4,  ParameterName = "Параметра №4",  MeasuredValue = 40, RequiredValue = 40 },
            new Parameters() { TestId = 2, ParametrId = 5,  ParameterName = "Параметра №5",  MeasuredValue = 50, RequiredValue = 50 },
            new Parameters() { TestId = 2, ParametrId = 6,  ParameterName = "Параметра №6",  MeasuredValue = 60, RequiredValue = 60 },
            new Parameters() { TestId = 3, ParametrId = 7,  ParameterName = "Параметра №7",  MeasuredValue = 70, RequiredValue = 70 },
            new Parameters() { TestId = 4, ParametrId = 8,  ParameterName = "Параметра №8",  MeasuredValue = 80, RequiredValue = 80 },
            new Parameters() { TestId = 4, ParametrId = 9,  ParameterName = "Параметра №9",  MeasuredValue = 90, RequiredValue = 90 },
            new Parameters() { TestId = 4, ParametrId = 10, ParameterName = "Параметра №10", MeasuredValue = 10, RequiredValue = 10 },
            new Parameters() { TestId = 4, ParametrId = 11, ParameterName = "Параметра №11", MeasuredValue = 20, RequiredValue = 20 },
            new Parameters() { TestId = 2, ParametrId = 12, ParameterName = "Параметра №12", MeasuredValue = 30, RequiredValue = 30 },
            new Parameters() { TestId = 1, ParametrId = 13, ParameterName = "Параметра №13", MeasuredValue = 40, RequiredValue = 40 },
            new Parameters() { TestId = 0, ParametrId = 14, ParameterName = "Параметра №14", MeasuredValue = 50, RequiredValue = 50 },
            new Parameters() { TestId = 1, ParametrId = 15, ParameterName = "Параметра №15", MeasuredValue = 60, RequiredValue = 60 },
            new Parameters() { TestId = 4, ParametrId = 16, ParameterName = "Параметра №16", MeasuredValue = 70, RequiredValue = 70 },

        };


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
