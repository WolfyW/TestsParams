using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestsParams.Model;
using TestsParams.MVVM;

namespace TestsParams.ViewModel
{
    class AddChangeParametersViewModel : INotifyPropertyChanged
    {
        private Parameters param;
        private bool isAdd;

        public AddChangeParametersViewModel(ChangeDelegate changeDelegate, Parameters param, string testName)
        {
            isAdd = false;
            this.param = param;
            this.TestName = testName;
            this.changeDelegate = changeDelegate;
        }
        public AddChangeParametersViewModel(AddDelegate<Parameters> addDelegate, string testName)
        {
            isAdd = true;
            param = new Parameters();
            this.TestName = testName;
            this.addDelegate = addDelegate;
        }

        public string TestName { get; }

        private ChangeDelegate changeDelegate;
        private AddDelegate<Parameters> addDelegate;

        public string ParameterName
        {
            get
            {
                return param.ParameterName;
            }
            set
            {
                param.ParameterName = value;
                OnPropertyChanged();
            }
        }
        public decimal RequiredValue
        {
            get
            {
                return param.RequiredValue;
            }
            set
            {
                param.RequiredValue = value;
                OnPropertyChanged();
            }
        }
        public decimal MeasuredValue
        {
            get
            {
                return param.MeasuredValue;
            }
            set
            {
                param.MeasuredValue = value;
                OnPropertyChanged();
            }
        }
        public string ButtonName
        {
            get
            {
                if (isAdd)
                    return "Add Parametr";
                else
                    return "Save Changes";
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (isAdd)
                {
                    return addCommand ?? (addCommand = new RelayCommand(obj =>
                    {
                        addDelegate(param);
                        ((Window)obj).Close();
                    }));
                }
                else
                {
                    return addCommand ?? (addCommand = new RelayCommand(obj =>
                    {
                        changeDelegate();
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
