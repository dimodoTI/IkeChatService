
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


    public class ChatController : ControllerBase
    {
        private readonly ChatContext _context;
        private readonly IWebSocketWrapper _webSocketWrapper = null;

        string _openMessage = JsonSerializer.Serialize(new { type = "new-connection", id = "ike", rol = "ike", name = "ike" });

        private readonly Permissions _permissions;

        public ChatController(ChatContext context, IWebSocketWrapper webSocketWrapper)
        {
            _context = context;

            _permissions = new Permissions();

            _webSocketWrapper = webSocketWrapper;

            _webSocketWrapper.OnConnect(
               wrapper =>
               {

                   wrapper.SendMessage(_openMessage);
               });

            // _webSocketWrapper.OnDisconnect(wrapper => _logger.LogInformation("desconectado"));

            //_webSocketWrapper.OnMessage((message, wrapper) => _logger.LogInformation(message));

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Put(int id, [FromBody] Chat chat)
        {
            if (id != chat.Id)
            {
                return BadRequest();
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Chat> chatPatch)
        {


            Chat chat = await _context.Chat.FirstOrDefaultAsync(u => u.Id == id);

            if (chat == null)
            {
                return NotFound();
            }

            try
            {
                chatPatch.ApplyTo(chat);

                _context.Entry(chat).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]

        public async Task<ActionResult<Chat>> Post(Mensaje mensaje)
        {


            string rols = _permissions.getUserRol(this.User);

            mensaje.Chat.UsuarioId = _permissions.getUserId(this.User); ;

            Reservas reserva;

            string refreshMessage = "";

            Chat preguntaOriginal = null;

            if (mensaje.PreguntaId != 0)
            {
                reserva = _context.Reservas.FirstOrDefault(r => r.Id == mensaje.Chat.ReservaId);

                if (reserva == null) return NotFound();

                preguntaOriginal = _context.Chat.FirstOrDefault(c => c.Id == mensaje.PreguntaId);

                if (preguntaOriginal != null) preguntaOriginal.Respondido = DateTime.Now.Ticks;

                refreshMessage = JsonSerializer.Serialize(new { type = "do-action", toRol = "cli", toId = reserva.UsuarioId, action = "REFRESH" });
            }
            else
            {
                reserva = _context.Reservas.FirstOrDefault(r => r.Id == mensaje.Chat.ReservaId && r.UsuarioId == mensaje.Chat.UsuarioId);

                if (reserva == null) return NotFound();

                refreshMessage = JsonSerializer.Serialize(new { type = "do-action", toRol = "vet", action = "REFRESH" });
            };


            _context.Chat.Add(mensaje.Chat);

            await _context.SaveChangesAsync();

            _webSocketWrapper.SendMessage(refreshMessage);

            return Ok();
        }




        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Chat>> Delete(int id)
        {
            var chat = await _context.Chat.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            _context.Chat.Remove(chat);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool Exists(int id)
        {
            return _context.Chat.Any(e => e.Id == id);
        }

    }

    public class Mensaje
    {
        public Chat Chat { get; set; }
        public int PreguntaId { get; set; }
    }

}
