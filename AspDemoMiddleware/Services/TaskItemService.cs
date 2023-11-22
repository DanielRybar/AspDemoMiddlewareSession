using AspDemoMiddleware.Models;

namespace AspDemoMiddleware.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ISessionStorage<List<TaskItem>> _ss;

        const string MY_KEY = "taskItems2023";

        public TaskItemService(ISessionStorage<List<TaskItem>> ss)
        {
            _ss = ss;
        }

        public List<TaskItem> GetTaskItems()
        {
            var items = _ss.LoadOrCreate(MY_KEY)!; // nacteni
            return items;
        }

        public TaskItem? CreateTaskItem(TaskItem taskItem)
        {
            var items = _ss.LoadOrCreate(MY_KEY)!; // nacteni
            items.Add(taskItem);
            _ss.Save(MY_KEY, items); // ulozeni
            return taskItem;
        }

        public TaskItem? DeleteTaskItem(int id)
        {
            var items = _ss.LoadOrCreate(MY_KEY)!; // nacteni
            var task = items.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                items.Remove(task);
                _ss.Save(MY_KEY, items); // ulozeni
                return task;
            }
            return null;
        }

        public void DeleteAllTaskItems()
        {
            var items = _ss.LoadOrCreate(MY_KEY)!; // nacteni
            items.Clear();
            _ss.Save(MY_KEY, items); // ulozeni
        }

        public TaskItem? FinishTaskItem(int id)
        {
            var items = _ss.LoadOrCreate(MY_KEY)!; // nacteni
            var task = items.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                _ss.Save(MY_KEY, items); // ulozeni
                return task;
            }
            return null;
        }

        public TaskItem? GetTaskItem(int id)
        {
            throw new NotImplementedException();
        }

        public TaskItem UpdateTaskItem(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}