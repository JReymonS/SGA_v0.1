namespace Entidades
{
    public class Modulos
    {
        public Modulos(int Id_modulo, string Nombre, string Descripcion)
        {
            id_modulo = Id_modulo;
            nombre = Nombre;
            descripcion = Descripcion;
        }

        public int id_modulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
