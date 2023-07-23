using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.ApplicationCore.Common.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
