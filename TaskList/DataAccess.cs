using System;
using TaskList.ViewModel;
using Dapper;
using System.Linq;
using System.Collections.ObjectModel;

namespace TaskList
{
    public class DataAccess
    {
        public ObservableCollection<Task> GetTasks(bool showAllTasks)
        {
            using var con = Helper.Conn();

            con.Open();

            string getTasks;

            if (showAllTasks)
            {
                getTasks = "SELECT * FROM Tasks ORDER BY Complete, TaskId DESC";
            }
            else if (!showAllTasks)
            {
                getTasks = "SELECT * from Tasks WHERE Complete = 'false' ORDER BY TaskId DESC";
            }
            else getTasks = "";

            ObservableCollection<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(getTasks).ToList());

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
        public void RemoveTask(string name)
        {
            using var con = Helper.Conn();

            con.Open();

            String dapperDelete = "DELETE FROM dbo.[Tasks] WHERE Name = @Name";

            var affectedRows = con.Execute(dapperDelete, new { Name = name });
        }
        public void IsChecked(string name, bool complete)
        {
            using var con = Helper.Conn();

            con.Open();

            String dapperChecked = "UPDATE Tasks SET Complete = @Complete WHERE Name = @Name";

            var affectedRows = con.Execute(dapperChecked, new { Complete = complete, Name = name });
        }
        public ObservableCollection<Task> ShowAll()
        {
            using var con = Helper.Conn();

            con.Open();

            string dapperShowAll = "SELECT * FROM Tasks ORDER BY TaskId DESC";
            
            ObservableCollection<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(dapperShowAll).ToList());

            return taskList;
        }
    }
}
