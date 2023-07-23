using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.ApplicationCore.Common.Entities;

namespace ToDoApplication.ApplicationCore.Common.Interfaces
{
    public interface IToDoService
    {
        IEnumerable<ToDoItem> GetAllToDoItems();
        ToDoItem GetToDoItem(int id);
        void AddToDoItem(ToDoItem toDoItem);
        void UpdateToDoItem(int id);
        void DeleteToDoItem(int id);
        void DeleteAll();
    }
}
