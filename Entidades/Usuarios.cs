namespace Entidades
{
    public class Usuarios
    {
        public Usuarios(int id_usuario, string nombre, string apellido_paterno, string apellido_materno, string clave, string status, int fkid_rol)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.apellido_paterno = apellido_paterno;
            this.apellido_materno = apellido_materno;
            this.clave = clave;
            this.status = status;
            this.fkid_rol = fkid_rol;
        }

        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string clave { get; set; }
        public string status { get; set; }
        public int fkid_rol {get; set;}
    }
}
