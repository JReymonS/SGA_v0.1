namespace Entidades
{
    public class DetalleEntradas
    {
        public DetalleEntradas(int Id_detalleEntrada, double Precio_entrada, int Cantidad_entrada, int Fkid_producto, int Fkid_entrada)
        {
            id_detalleEntrada = Id_detalleEntrada;
            precio_entrada = Precio_entrada;
            cantidad_entrada = Cantidad_entrada;
            fkid_producto = Fkid_producto;
            fkid_entrada = Fkid_entrada;
        }

        public int id_detalleEntrada { get; set; }
        public double precio_entrada { get; set; }
        public int cantidad_entrada { get; set; }
        public int fkid_producto { get; set; }
        public int fkid_entrada { get; set; }
    }
}
