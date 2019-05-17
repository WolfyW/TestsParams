using System.Windows;
using TestsParams.Model;
using TestsParams.ViewModel;

namespace TestsParams.View
{
    /// <summary>
    /// Interaction logic for AddChangeTest.xaml
    /// </summary>
    public partial class AddChangeTest : Window
    {
        public AddChangeTest(AddDelegate<Tests> addDelegate)
        {
            InitializeComponent();
            DataContext = new AddChangeTestViewModel(addDelegate);
        }

        public AddChangeTest(ChangeDelegate changeDelegate, Tests tests)
        {
            InitializeComponent();
            DataContext = new AddChangeTestViewModel(changeDelegate, tests);
        }
    }
}
