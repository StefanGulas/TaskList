using System.Windows;
using TaskList.ViewModel;



namespace TaskList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskListViewModel tasks = new TaskListViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = tasks;

        }
    }
}
