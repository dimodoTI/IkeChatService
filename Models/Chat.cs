
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
        public int Leido { get; set; }
        public int Respondido { get; set; }
        public Reservas Reserva { get; set; }
    }
}
