using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMyTodo.Data;
using ApiMyTodo.Models;
using ApiMyTodo.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ApiMyTodo.Controllers
{
    [Authorize]
    [Route("api/todo")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly ApiMyTodoContext _context;



        public TodoesController(ApiMyTodoContext context)
        {
            _context = context;

        }

        // GET: api/Todoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()

        {
            var userN = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Name);
            var todo = _context.Todos.Where(z => z.UserNameId == userN.Value).Where(z => z.IsDone == false);
            return await todo.ToListAsync();
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todoes/5
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            //Edytuje tylko dwa pola IsDone & IsUse
            var data = _context.Todos.Find(id);
            data.Title = todo.Title;
            data.Description = todo.Description;
            data.IsDone = todo.IsDone;
            data.IsUse = todo.IsUse;

            _context.Todos.Update(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Todoes

        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            var userN = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Name);

            //*****************************
            todo.UserNameId = userN.Value;
            _context.Todos.Add(todo);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
