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
        private string taskName;

        public TaskListViewModel()
        {
     
            Tasks = new ObservableCollection<Task>();
            Tasks.Add(new Task() { Name = "Task 1", Priority = 0, Complete = true });
            Tasks.Add(new Task() { Name = "Task 2", Complete = false, Priority =  0 });
        }
        
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value;
                NotifyPropertyChanged(nameof(Tasks));    
            }

        }
        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                NotifyPropertyChanged(nameof(TaskName));
            }
        }
        public bool TaskIsChecked { get; set; }

        //private Priority taskPriority;
        //public Priority TaskPriority 
        //{ 
        //    get { return taskPriority; }  
        //    set { taskPriority = value;
        //        NotifyPropertyChanged(nameof(TaskPriority));
        //        }  
        //}
        public IList<Priority> TaskPriorities
        {
            get
            {
                // Will result in a list like {"Tester", "Engineer"}
                return Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList<Priority>();
            }
            set { }
        }
        private Priority priority;

        public Priority Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                NotifyPropertyChanged(nameof(Priority));
            }

        }

        //public string TaskPriority { get; set; }
        public bool ClearTask { get; set; }

        //public int LengthOfTaksList()
        //{
        //    int length = Tasks.Count();

        //    return length;
        //}
        
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }
        
        public ICommand ClearTaskCommand { get { return new ClearTaskCommand(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
