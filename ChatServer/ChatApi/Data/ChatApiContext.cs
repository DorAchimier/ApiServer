using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatApi.Models;

namespace ChatApi.Data
{
    public class ChatApiContext : DbContext
    {
        public ChatApiContext (DbContextOptions<ChatApiContext> options)
            : base(options)
        {
        }

        public DbSet<ChatApi.Models.User>? User { get; set; }

        public DbSet<ChatApi.Models.Message>? Message { get; set; }

        public DbSet<ChatApi.Models.Chat>? Chat { get; set; }
    }
}
