using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChatApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class ChatQueryController : ControllerBase
    {
        private readonly ChatContext _context;


        public ChatQueryController(ChatContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Chat> Get()
        {

            IQueryable<Chat> chat = _context.Chat.AsQueryable();

            return chat;
        }
    }
}
