using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskList.ViewModel;

namespace TaskList.Command
{
    public class ClearTaskCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is TaskListViewModel taskList)
            {
                if (taskList.TaskName == null)
                {
                    taskList.TaskName = "";
                }
                for (int i = 0; i < taskList.Tasks.Count; i++)
                {
                    if (taskList.TaskName == null) taskList.TaskName = "";
                    if (taskList.Tasks[i].Name == taskList.TaskName)
                    {
                        taskList.Tasks.RemoveAt(i);
                        taskList.TaskName = "";
                        break;
                    }
                }
                
            }
        }
    }
}
