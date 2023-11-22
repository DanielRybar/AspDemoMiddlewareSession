using AspDemoMiddleware.Models;
using AspDemoMiddleware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspDemoMiddleware.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITaskItemService _tis;
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

        public IndexModel(ITaskItemService service)
        {
            _tis = service;
        }

        public void OnGet()
        {
            TaskItems = _tis.GetTaskItems();
        }

        public IActionResult OnGetAddTask()
        {
            TaskItems = _tis.GetTaskItems();
            int count = TaskItems.Count;
            var taskItem = new TaskItem()
            {
                Id = count + 1,
                Name = $"úkol {count + 1}",
                End = DateTime.Now.AddDays(count + 1),
                IsCompleted = Random.Shared.Next(0, 2) == 0
            };

            _tis.CreateTaskItem(taskItem);

            return RedirectToPage("/Index");
        }

        public IActionResult OnGetDeleteTask(int taskId)
        {
            _tis.DeleteTaskItem(taskId);
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetRemoveAll()
        {
            _tis.DeleteAllTaskItems();
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetFinished(int id)
        {
            _tis.FinishTaskItem(id);
            return RedirectToPage("/Index");
        }
    }
}