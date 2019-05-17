﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestsParams.Model;

namespace TestsParams.ViewModel
{
    class AddChangeParametersViewModel : INotifyPropertyChanged
    {
        private Parameters param;
        public bool AddChange { get; } = true;
        public AddChangeParametersViewModel(Parameters param)
        {
            this.param = param;
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}