using System;
using System.Collections.Generic;
using System.Text;
using TaskList.ViewModel;
using Dapper;
using System.Linq;
using System.Collections.ObjectModel;

namespace TaskList
{
    public class DataAccess
    {
        public ObservableCollection<Task> GetTasks()
        {
            using var con = Helper.Conn();

            con.Open();

            ObservableCollection<Task> taskList = new ObservableCollection<Task>(con.Query<Task>("SELECT * from Tasks").ToList());

            con.Close();

            return taskList;
        }

        public void AddTask(Task newTask)
        {
            using var con = Helper.Conn();

            con.Open();

            con.Execute("INSERT INTO dbo.[Tasks] VALUES newTask");

        }
    }
}
