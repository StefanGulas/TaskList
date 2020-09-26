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

        public void AddTask(string name, int priority, bool complete)
        {
            using var con = Helper.Conn();

            con.Open();

            String dapperInsert = "INSERT INTO dbo.[Tasks] (Name, Priority, Complete) VALUES" +
                "(@Name, @Priority, @Complete)";
            var affectedRows = con.Execute(dapperInsert, new { Name = name, Priority = priority, Complete = complete });

        }

    }
}
