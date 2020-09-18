using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.ViewModel
{
        public enum Priority
        {
            low,
            medium,
            high
        }

    public class Task
    {
        public string Name { get; set; }
        public bool Complete { get; set; }
        public Priority Priority { get; set; }

    }
}
