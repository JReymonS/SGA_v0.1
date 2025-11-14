using System.Collections.Generic;

namespace Entidades
{
    public class Roles
    {
        public Roles(int Id_rol, string Nombre, string Identificador)
        {
            id_rol = Id_rol;
            nombre = Nombre;
            identificador = Identificador;
            permisos = new List<Permisos>();
        }

        public int id_rol { get; set; }
        public string nombre { get; set; }
        public string identificador { get; set; }

        //PERMISOS ASOCIADOS AL ROL
        public List<Permisos> permisos { get; set; }
    }
}
