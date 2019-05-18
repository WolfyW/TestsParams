﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using TestsParams.ViewModel;
using TestsParams.Model;

namespace TestsParams.View
{
    /// <summary>
    /// Interaction logic for AddChangeParametr.xaml
    /// </summary>
    public partial class AddChangeParametr : Window
    {
        public AddChangeParametr(AddDelegate<Parameters> addDelegate, string testName)
        {
            InitializeComponent();
            DataContext = new AddChangeParametersViewModel(addDelegate, testName); 
        }

        public AddChangeParametr(ChangeDelegate changeDelegate, Parameters parameters, string testName)
        {
            InitializeComponent();
            DataContext = new AddChangeParametersViewModel(changeDelegate, parameters, testName);
        }
    }
}