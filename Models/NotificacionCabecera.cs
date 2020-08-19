
using System;
using System.Collections.Generic;

namespace ChatApi.Models
{
    public class NotificacionCabecera
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Link { get; set; }
        public string Para { get; set; }
        public Usuarios Usuario { get; set; }
        public List<NotificacionDetalle> Detalle { get; set; }
    }
}
