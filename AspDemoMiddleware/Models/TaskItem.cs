namespace AspDemoMiddleware.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime End { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}