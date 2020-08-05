
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

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ChatController : ControllerBase
    {
        private readonly ChatContext _context;
        private readonly IWebSocketWrapper _webSocketWrapper = null;

        string _openMessage = JsonSerializer.Serialize(new { type = "new-connection", id = "ike", rol = "ike", name = "ike" });

        public ChatController(ChatContext context, IWebSocketWrapper webSocketWrapper)
        {
            _context = context;

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
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<Chat>> Post(Chat chat)
        {


            _context.Chat.Add(chat);

            await _context.SaveChangesAsync();

            //string refreshMessage = JsonSerializer.Serialize(new { type = "do-action", toRol = "vet", action = "REFRESH" });

            //string refreshMessage = JsonSerializer.Serialize(new { type = "do-action", toRol = "cli",toId="1234", action = "REFRESH" });

            //_webSocketWrapper.SendMessage(refreshMessage);

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

}