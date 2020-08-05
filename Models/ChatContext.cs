using Microsoft.EntityFrameworkCore;

namespace ChatApi.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Reservas> Reservas { get; set; }







    }
}