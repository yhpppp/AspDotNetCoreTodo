using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreTodo.Models
{
    public class TodoItem
    {
        // 全局唯一标识符
        public Guid Id { get; set; }
        // 完成状态
        public bool IsDone { get; set; }
        // 待办事项名称
        public string Title { get; set; }
        // 截止时间(可为空)
        public DateTimeOffset? DueAt { get; set; }


    }
}
