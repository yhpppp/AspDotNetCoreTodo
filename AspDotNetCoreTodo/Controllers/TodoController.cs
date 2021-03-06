using AspDotNetCoreTodo.Models;
using AspDotNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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

        //添加一項
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
     
            var successful = await _todoItemService.AddItemAsync(newItem);

            if (!successful)
            {
                return BadRequest("Could not add item");
            }
            return RedirectToAction("Index");
        }

        // 处理完成项
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if(id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);

            if(!successful)
            {
                return BadRequest("Could not mark item as done");
            }

            return RedirectToAction("Index");
        }
    }
}