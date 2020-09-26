namespace TaskList.ViewModel
{
    public enum Priority
        {
            low = 0,
            medium = 1,
            high = 2
        }

    public class Task
    {
        public string Name { get; set; }
        public bool Complete { get; set; }
        public Priority Priority { get; set; }

    }
}
