using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using message_board.Models;

namespace message_board.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoMessage> TodoItems { get; set; }

        public DbSet<message_board.Models.TodoMessage> TodoMessage { get; set; }
    }
}
