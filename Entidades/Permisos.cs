namespace Entidades
{
    public class Permisos
    {
        public Permisos(int Id_permiso, string Permiso_crear, string Permiso_leer, string Permiso_modificar, string Permiso_borrar, int Fkid_rol, int Fkid_modulo)
        {
            id_permiso = Id_permiso;
            permiso_crear = Permiso_crear;
            permiso_leer = Permiso_leer;
            permiso_modificar = Permiso_modificar;
            permiso_borrar = Permiso_borrar;
            fkid_rol = Fkid_rol;
            fkid_modulo = Fkid_modulo;
        }

        public int id_permiso { get; set; }
        public string permiso_crear { get; set; }
        public string permiso_leer { get; set; }
        public string permiso_modificar { get; set; }
        public string permiso_borrar { get; set; }
        public int fkid_rol { get; set; }
        public int fkid_modulo { get; set; }

    }
}
