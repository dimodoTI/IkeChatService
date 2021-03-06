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
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Mascotas> Mascotas { get; set; }
        public DbSet<NotificacionCabecera> NotificacionCabecera { get; set; }
        public DbSet<NotificacionDetalle> NotificacionDetalle { get; set; }







    }
}