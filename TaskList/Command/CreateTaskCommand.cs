using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskList.ViewModel;

namespace TaskList.Command
{
    public class CreateTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        //TaskListViewModel tasks = new TaskListViewModel();
        public bool CanExecute(object parameter)
        {
            //if (tasks.LengthOfTaksList() > 5)
            //{
            //    return false;
            //}
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is TaskListViewModel taskList)
            {
                taskList.Tasks.Add(new Task() { Name = taskList.TaskName, Complete = false });
            }
        }
    }
}
