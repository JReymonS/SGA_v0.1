namespace Entidades
{
    public class Productos
    {
        public Productos(int Id_producto, string Nombre, string Descripcion, string Unidad, double Precio_salida, int Stock, int Stock_minimo, string Status, int Fkid_categoria)
        {
            id_producto = Id_producto;
            nombre = Nombre;
            descripcion = Descripcion;
            unidad = Unidad;
            precio_salida = Precio_salida;
            stock = Stock;
            stock_minimo = Stock_minimo;
            status = Status;
            fkid_categoria = Fkid_categoria;
        }

        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string unidad { get; set; }
        public double precio_salida { get; set; }
        public int stock { get; set; }
        public int stock_minimo { get; set; }
        public string status { get; set; }
        public int fkid_categoria { get; set; }
    }
}
