namespace Entidades
{
    public class DetalleSalidas
    {
        public DetalleSalidas(int Id_detalleSalida, double Precio_salida_actual, int Cantidad_salida, int Fkid_producto, int Fkid_salida)
        {
            id_detalleSalida = Id_detalleSalida;
            precio_salida_actual = Precio_salida_actual;
            cantidad_salida = Cantidad_salida;
            fkid_producto = Fkid_producto;
            fkid_salida = Fkid_salida;
        }

        public int id_detalleSalida { get; set; }
        public double precio_salida_actual { get; set; }
        public int cantidad_salida { get; set; }
        public int fkid_producto { get; set; }
        public int fkid_salida { get; set; }
    }
}
