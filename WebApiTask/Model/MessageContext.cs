using Microsoft.EntityFrameworkCore;

namespace WebApiTask.Model
{
    public class MessageContext:DbContext
    {
        public DbSet<Message>Messages { get; set; }

        public MessageContext(DbContextOptions<MessageContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
