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
        {   // �����ݿ��ȡ to-do ��Ŀ
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // ����Ŀ���� model ��
            var model = new TodoViewModel() { Items = items };
            // ʹ�� model ��Ⱦ��ͼ
            return View(model);
        }
    }
}