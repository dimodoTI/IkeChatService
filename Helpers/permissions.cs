using System.Security.Claims;
using System.Linq;

namespace ChatApi.Helpers
{
    public class Permissions
    {
        public bool isOwnerOrAdmin(ClaimsPrincipal currentUser, int IdOwner)
        {

            int idUsuario;

            Claim rolUsuario = currentUser.Claims.FirstOrDefault(r => r.Type == ClaimTypes.Role);

            if (rolUsuario == null) return false;

            var res = int.TryParse(currentUser.Identity.Name, out idUsuario);

            return (rolUsuario.Value == "Admin" || IdOwner == idUsuario);

        }
        public bool isAdmin(ClaimsPrincipal currentUser)
        {

            Claim rolUsuario = currentUser.Claims.FirstOrDefault(r => r.Type == ClaimTypes.Role);

            if (rolUsuario == null) return false;

            return rolUsuario.Value == "Admin";

        }

        public bool isInRol(ClaimsPrincipal currentUser, string rol)
        {

            Claim rolUsuario = currentUser.Claims.FirstOrDefault(r => r.Type == ClaimTypes.Role);

            if (rolUsuario == null) return false;


            return rolUsuario.Value.ToUpper().Split(" ").Contains(rol.ToUpper());

        }

        public int getUserId(ClaimsPrincipal currentUser)
        {

            int idUsuario;
            var res = int.TryParse(currentUser.Identity.Name, out idUsuario);
            return idUsuario;
        }

        public string getUserRol(ClaimsPrincipal currentUser)
        {

            Claim rolUsuario = currentUser.Claims.FirstOrDefault(r => r.Type == ClaimTypes.Role);

            if (rolUsuario == null) return "";

            return rolUsuario.Value;
        }



    }
}