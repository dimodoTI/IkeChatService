
using System;
using System.Collections.Generic;

namespace ChatApi.Models
{

    public class Chat
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; }
        public bool EsPregunta { get; set; }
        public long Leido { get; set; }
        public long Respondido { get; set; }
        public Reservas Reserva { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
