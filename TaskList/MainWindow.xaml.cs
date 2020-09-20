using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
//            TaskPriorityComboBox.ItemsSource = Enum.GetValues(typeof(TaskPriorities)).Cast<TaskPriorities>();

        }
    }
}
