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
        private Priority priority;

        public TaskListViewModel()
        {
            DataAccess db = new DataAccess();
            Tasks = db.GetTasks();

            //Tasks = new ObservableCollection<Task>();
        

            //    Tasks.Add(new Task() { Name = "Weekend Grocery", Priority = 0, Complete = false });
        //    Tasks.Add(new Task() { Name = "Finish Monthly Bookkeeping", Complete = true, Priority = ViewModel.Priority.high });
        
        }

        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
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

        public IList<Priority> TaskPriorities
        {
            get
            {
                return Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList<Priority>();
            }
            set { }
        }

        public Priority Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                NotifyPropertyChanged(nameof(Priority));
            }

        }

        public bool ClearTask { get; set; }

        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        public ICommand ClearTaskCommand { get { return new ClearTaskCommand(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
