using AspDemoMiddleware.Models;

namespace AspDemoMiddleware.Services
{
    public interface ITaskItemService
    {
        List<TaskItem> GetTaskItems();
        TaskItem? GetTaskItem(int id);
        TaskItem? CreateTaskItem(TaskItem taskItem);
        TaskItem? UpdateTaskItem(TaskItem taskItem);
        TaskItem? DeleteTaskItem(int id);
        TaskItem? FinishTaskItem(int id);
        void DeleteAllTaskItems();
    }
}