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
    public enum Priority
        {
            low = 0,
            medium = 1,
            high = 2
        }

    public class Task : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private bool complete;

        public int TaskId { get; set; }
        public bool Complete
        {
            get { return complete; }
            set
            {
                complete = value;
                NotifyPropertyChanged(nameof(Name));
                DataAccess db = new DataAccess();
                db.IsChecked(Name, complete);
            }
        }

        public Priority Priority { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
