using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using message_board.Models;
using Microsoft.Extensions.Logging;

namespace message_board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoMessagesController : ControllerBase
    {
        // For this service, a TodoContex used as DbContecx for in datastore
        private readonly TodoContext _context;
        //in /logs folder located in the projects root folder 
        //Ilogger Interface is used to instiantiate a logger for logging the <TodoMessagesController> behaviour   
        ILogger<TodoMessagesController> logger;

        public object ScriptManager { get; }

        public TodoMessagesController(TodoContext context, ILogger<TodoMessagesController> logger)
        {
            try
            {
                if (context!=null)
                {
                    _context = context;
                    this.logger = logger;
                }
                
                
            }
            catch (Exception ex)
            {
                logger.LogError("Eror creating a contex");                
            }
        }


        // GET: api/TodoMessages

        // The below async method returns a list of messages available in the  _context.TodoMessage 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoMessage>>> GetTodoMessage()
        {
            //var messages = _context.TodoMessage.ToListAsync();
            return await _context.TodoMessage.ToListAsync();
        }

        // GET: api/TodoMessages/5
        // The below async method allows message listing by id parameter
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoMessage>> GetTodoMessage(long id)
        {
            var todoMessage = await _context.TodoMessage.FindAsync(id);

            if (todoMessage == null)
            {
                return NotFound();
            }

            return todoMessage;
        }

        // PUT: api/TodoMessages/5
        // This method allows updating a message record by supplying the message id record
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoMessage(long id, TodoMessage todoMessage)
        {
            try
            {
                
                if (id != todoMessage.id)
                {
                    return BadRequest();
                }
                todoMessage.modifiedDate = DateTime.Now;
                _context.Entry(todoMessage).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoMessageExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/TodoMessages
        // This method handles the message creation and posting 
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoMessage>> PostTodoMessage(TodoMessage todoMessage)
        {

            try
            {
                todoMessage.posteDate = DateTime.Now;
                _context.TodoMessage.Add(todoMessage);
                await _context.SaveChangesAsync();
                logger.LogInformation("Post Added Successfully");               
                return CreatedAtAction(nameof(GetTodoMessage), new { id = todoMessage.id }, todoMessage);

            }
            catch (Exception ex)

            {
                logger.LogError("Eror Adding Post");
                return CreatedAtAction("GetTodoMessage",ex.ToString());
            }

        }

        // DELETE: api/TodoMessages/5
        // This method is used to delete a message record by id parameter
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoMessage>> DeleteTodoMessage(long id)
        {

            try
            {
                var todoMessage = await _context.TodoMessage.FindAsync(id);
                if (todoMessage == null)
                {
                    logger.LogError("No valid message id entered");
                    return NotFound();
                }

                _context.TodoMessage.Remove(todoMessage);
                await _context.SaveChangesAsync();
                logger.LogInformation("Post Deleted Successfully");
                return todoMessage;
            }
            catch (Exception ex)
            {
                logger.LogError("Error encountered deleting post");
                logger.LogError(ex.ToString());
                return null;
            }
        }

        private bool TodoMessageExists(long id)
        {
            return _context.TodoMessage.Any(e => e.id == id);
        }
    }
}
