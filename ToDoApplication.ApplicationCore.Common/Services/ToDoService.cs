using Microsoft.EntityFrameworkCore;
using ToDoApplication.ApplicationCore.Common.Entities;
using ToDoApplication.ApplicationCore.Common.Infastructure;
using ToDoApplication.ApplicationCore.Common.Interfaces;

namespace ToDoApplication.ApplicationCore.Common.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext _context;

        public ToDoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoItem> GetAllToDoItems()
        {
            return _context.ToDoItem.ToList();
        }

        public ToDoItem GetToDoItem(int id)
        {
            return _context.ToDoItem.Find(id);
        }

        public void AddToDoItem(ToDoItem toDoItem)
        {
            toDoItem.Created = DateTime.Now;
            toDoItem.Updated = DateTime.Now;
            _context.ToDoItem.Add(toDoItem);
            _context.SaveChanges();
        }

        public void UpdateToDoItem(int id)
        {
            var item = _context.ToDoItem.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Updated = DateTime.Now;
                item.IsComplete = true;
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Item with the specified ID does not exist.");
            }
        }

        public void DeleteToDoItem(int id)
        {
            var toDoItem = _context.ToDoItem.Find(id);
            if (toDoItem != null)
            {
                _context.ToDoItem.Remove(toDoItem);
                _context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            var allToDoItems = _context.ToDoItem.ToList();
            _context.ToDoItem.RemoveRange(allToDoItems);
            _context.SaveChanges();
        }
    }
}
