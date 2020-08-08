using System;
using System.Collections.Generic;

namespace ChatApi.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public int TramoId { get; set; }
        public int MascotaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaAtencion { get; set; }
        public int HoraAtencion { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Motivo { get; set; }
        public int Estado { get; set; }
        public int Calificacion { get; set; }
        public String ComentarioCalificacion { get; set; }
        public bool Activo { get; set; }
        public List<Chat> chats { get; set; }


    }
}