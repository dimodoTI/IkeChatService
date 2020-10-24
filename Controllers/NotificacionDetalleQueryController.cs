using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChatApi.Models;
using Microsoft.AspNet.OData;

namespace ChatApi.Controllers
{

    public class NotificacionDetalleQueryController : ControllerBase
    {
        private readonly ChatContext _context;


        public NotificacionDetalleQueryController(ChatContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<NotificacionDetalle> Get()
        {

            IQueryable<NotificacionDetalle> notificaciones = _context.NotificacionDetalle.AsQueryable();

            return notificaciones;
        }
    }
}
