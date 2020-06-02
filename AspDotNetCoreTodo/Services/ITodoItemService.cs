using AspDotNetCoreTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        // 获取未完成项
        Task<TodoItem[]> GetIncompleteItemsAsync();

        // 添加一項
        Task<bool> AddItemAsync(TodoItem newItem);
    }
}
