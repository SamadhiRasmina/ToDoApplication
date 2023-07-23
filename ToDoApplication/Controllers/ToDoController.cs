using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.ApplicationCore.Common.Entities;
using ToDoApplication.ApplicationCore.Common.Infastructure;
using ToDoApplication.ApplicationCore.Common.Interfaces;

namespace ToDoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: api/ToDoItem
        [HttpGet("GetToDoList")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems()
        {
            var toDoItems = _toDoService.GetAllToDoItems();
            return Ok(toDoItems);
        }

        // GET: api/ToDoItem/5
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetToDoItem(int id)
        {
            var toDoItem = _toDoService.GetToDoItem(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }

        // POST: api/ToDoItem
        [HttpPost("CreateToDoItem")]
        public IActionResult PostToDoItem(ToDoItem toDoItem)
        {
            _toDoService.AddToDoItem(toDoItem);
            return CreatedAtAction(nameof(GetToDoItem), new { id = toDoItem.Id }, toDoItem);
        }

        // PUT: api/ToDoItem/5
        [HttpPut("CompleteToDoItem/{id}")]
        public IActionResult PutToDoItem(int id)
        {
            try
            {
                _toDoService.UpdateToDoItem(id);
                return Ok("Successfully completed!");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Invalid Id");
            }
        }

        // DELETE: api/ToDoItem/5
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoItem(int id)
        {
            _toDoService.DeleteToDoItem(id);
            return Ok("Successfully deleted!");
        }

        // DELETE: api/ToDoItem
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAllToDoItems()
        {
            _toDoService.DeleteAll();
            return Ok("Successfully deleted!");
        }
    }
}
