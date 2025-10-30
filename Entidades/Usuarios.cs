using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string clave { get; set; }
        public string status { get; set; }
        public int fkid_rol {get; set;}
        //FALTA AGREGAR LOS PERMISOS MEDIANTE UNA CONSULTA DEL TIPO DE ROL
    }
}
