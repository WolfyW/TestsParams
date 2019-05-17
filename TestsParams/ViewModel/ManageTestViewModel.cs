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
                Parametrs = new ObservableCollection<Parameters>(InsteadDB.GetParametrs(selectedItem));

                OnPropertyChanged();
            }
        }

        public ManageTestViewModel()
        {
            tests = new ObservableCollection<Tests>(InsteadDB.GetTests());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
