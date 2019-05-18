using System.Windows;
using TestsParams.Model;
using TestsParams.ViewModel;

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
