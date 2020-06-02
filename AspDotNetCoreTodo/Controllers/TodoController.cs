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
        {   // �����ݿ��ȡ to-do ��Ŀ
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // ����Ŀ���� model ��
            var model = new TodoViewModel() { Items = items };
            // ʹ�� model ��Ⱦ��ͼ
            return View(model);
        }

        //���һ�
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

        // ���������
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