using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using webSocket;
using System.Text.Json;
using ChatApi.Helpers;


namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class NotificacionesController : ControllerBase
    {
        private readonly ChatContext _context;
        private readonly IWebSocketWrapper _webSocketWrapper = null;

        string _openMessage = JsonSerializer.Serialize(new { type = "new-connection", id = "ike", rol = "ike", name = "ike" });

        private readonly Permissions _permissions;

        public NotificacionesController(ChatContext context, IWebSocketWrapper webSocketWrapper)
        {
            _context = context;

            _permissions = new Permissions();

            _webSocketWrapper = webSocketWrapper;

            _webSocketWrapper.OnConnect(
               wrapper =>
               {

                   wrapper.SendMessage(_openMessage);
               });

        }


        [HttpPost]

        public async Task<ActionResult<Chat>> Post(NotificacionCabecera notificacion)
        {


            string rols = _permissions.getUserRol(this.User);

            notificacion.UsuarioId = _permissions.getUserId(this.User);

            notificacion.Fecha = DateTime.Now;

            _context.NotificacionCabecera.Add(notificacion);

            await _context.SaveChangesAsync();

            notificacion.Detalle.ForEach((det) =>
            {
                string refreshMessage = JsonSerializer.Serialize(new { type = "do-action", toRol = "cli", toId = det.ClienteId, action = "REFRESH_NOTIFICACION" });

                _webSocketWrapper.SendMessage(refreshMessage);

            });

            return Ok();
        }




        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Chat>> Delete(int id)
        {
            var cabecera = await _context.NotificacionCabecera.FindAsync(id);

            if (cabecera == null)
            {
                return NotFound();
            }

            _context.NotificacionCabecera.Remove(cabecera);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }


}
