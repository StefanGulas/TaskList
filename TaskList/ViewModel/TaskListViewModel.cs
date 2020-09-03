using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TaskList.Command;

namespace TaskList.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskViewModel> tasks;

        public ObservableCollection<TaskViewModel> Tasks
        {
            get { return tasks; }
            set { tasks = value;
                NotifyPropertyChanged(nameof(Tasks));    
            }

        }
        public string TaskName { get; set; }
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
