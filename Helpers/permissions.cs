using System.Security.Claims;
using System.Linq;

namespace ChatApi.Helpers
{
    public class Permissions
    {
        public bool isOwnerOrAdmin(ClaimsPrincipal currentUser, int IdOwner)
        {

            int idUsuario;
            string rolUsuario = currentUser.Claims.First(r => r.Type == ClaimTypes.Role).Value;
            var res = int.TryParse(currentUser.Identity.Name, out idUsuario);

            return (rolUsuario == "Admin" || IdOwner == idUsuario);

        }
        public bool isAdmin(ClaimsPrincipal currentUser)
        {

            string rolUsuario = currentUser.Claims.First(r => r.Type == ClaimTypes.Role).Value;

            return rolUsuario == "Admin";

        }

        public int getUserId(ClaimsPrincipal currentUser)
        {
            int idUsuario;
            var res = int.TryParse(currentUser.Identity.Name, out idUsuario);
            return idUsuario;
        }

        public string getUserRol(ClaimsPrincipal currentUser)
        {
            string rolUsuario = currentUser.Claims.First(r => r.Type == ClaimTypes.Role).Value;

            return rolUsuario;
        }



    }
}