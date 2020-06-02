using AspDotNetCoreTodo.Models;
using AspDotNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspDotNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {   // 从数据库获取 to-do 条目
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // 把条目置于 model 中
            var model = new TodoViewModel() { Items = items };
            // 使用 model 渲染视图
            return View(model);
        }
    }
}