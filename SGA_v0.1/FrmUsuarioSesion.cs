using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA_v0._1
{
    // ESTA CLASE PERMITE RECUPERAR EL USUARIO Y ROL PARA HACER USO DE EL EN OTROS FORMULARIOS
    public static class FrmUsuarioSesion
    {
        public static Usuarios Usuario { get; set; }
        public static Roles Rol { get; set; }
    }
}
