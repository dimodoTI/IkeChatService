using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChatApi.Models;
using Microsoft.AspNet.OData;

namespace ChatApi.Controllers
{

    public class NotificacionCabeceraQueryController : ControllerBase
    {
        private readonly ChatContext _context;


        public NotificacionCabeceraQueryController(ChatContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<NotificacionCabecera> Get()
        {

            IQueryable<NotificacionCabecera> notificaciones = _context.NotificacionCabecera.AsQueryable();

            return notificaciones;
        }
    }
}
