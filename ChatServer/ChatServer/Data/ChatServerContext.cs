using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatServer.Models;

namespace ChatServer.Data
{
    public class ChatServerContext : DbContext
    {
        public ChatServerContext (DbContextOptions<ChatServerContext> options)
            : base(options)
        {
        }

        public DbSet<ChatServer.Models.Rating>? Rating { get; set; }

        public DbSet<ChatServer.Models.User>? User { get; set; }
    }
}
