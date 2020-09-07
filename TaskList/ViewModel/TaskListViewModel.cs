using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TaskList.Command;

namespace TaskList.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Task> tasks;

        public TaskListViewModel()
        {

            Tasks = new ObservableCollection<Task>();
            Tasks.Add(new Task() { Name = "Task 1", Complete = true });
            Tasks.Add(new Task() { Name = "Task 2", Complete = false });
        }
        
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value;
                NotifyPropertyChanged(nameof(Tasks));    
            }

        }
        public string TaskName { get; set; }

        //public int LengthOfTaksList()
        //{
        //    int length = Tasks.Count();

        //    return length;
        //}
        
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
