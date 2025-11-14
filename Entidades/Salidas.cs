namespace Entidades
{
    public class Salidas
    {
        public Salidas(int Id_salida, string Fecha_salida, int Fkid_usuario)
        {
            id_salida = Id_salida;
            fecha_salida = Fecha_salida;
            fkid_usuario = Fkid_usuario;
        }

        public int id_salida { get; set; }
        public string fecha_salida { get; set; }
        public int fkid_usuario { get; set; }
    }
}
