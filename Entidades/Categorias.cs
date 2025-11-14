namespace Entidades
{
    public class Categorias
    {
        public Categorias(int Id_categoria, string Nombre, string Status)
        {
            id_categoria = Id_categoria;
            nombre = Nombre;
            status = Status;
        }

        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string status { get; set; }
    }
}
