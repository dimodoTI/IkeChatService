using System;
using System.Collections.Generic;

namespace ChatApi.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public string Perfil { get; set; }
        public List<Chat> Chats { get; set; }
    }
}