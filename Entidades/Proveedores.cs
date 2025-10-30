using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entidades
{
    public class Proveedores
    {
        public Proveedores(int Id_proveedor, string Nombre, string Apellido_paterno, string Apellido_materno, string Telefono, string Correo, int Plazo_disponibilidad, string Status)
        {
            id_proveedor = Id_proveedor;
            nombre = Nombre;
            apellido_paterno = Apellido_paterno;
            apellido_materno = Apellido_materno;
            telefono = Telefono;
            correo = Correo;
            plazo_disponibilidad = Plazo_disponibilidad;
            status = Status;
        }

        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public int plazo_disponibilidad { get; set; }
        public string status { get; set; }
    }
}
