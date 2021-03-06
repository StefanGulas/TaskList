﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskList.ViewModel;

namespace TaskList.Command
{
    public class CreateTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is TaskListViewModel taskList && taskList.TaskName != null && taskList.TaskName != "")
            {
                taskList.Tasks.Add(new Task() { Name = taskList.TaskName, Priority = taskList.Priority, Complete = taskList.TaskIsChecked });
                DataAccess db = new DataAccess();
                db.AddTask(taskList.TaskName, (int)taskList.Priority, taskList.TaskIsChecked);
                taskList.TaskName = "";

            }
        }
    }
}
