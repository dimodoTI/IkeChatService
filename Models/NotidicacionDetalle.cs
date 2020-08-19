
using System;
using System.Collections.Generic;

namespace ChatApi.Models
{
    public class NotificacionDetalle
    {
        public int Id { get; set; }
        public int CabeceraId { get; set; }
        public int ClienteId { get; set; }
        public int? MascotaId { get; set; }
        public long Leido { get; set; }
        public Usuarios Cliente { get; set; }
        public Mascotas Mascota { get; set; }
        public NotificacionCabecera Cabecera { get; set; }

    }
}
