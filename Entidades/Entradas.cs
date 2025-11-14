namespace Entidades
{
    public class Entradas
    {
        public Entradas(int Id_entrada, string Fecha_entrada, int Fkid_usuario, int Fkid_proveedor)
        {
            id_entrada = Id_entrada;
            fecha_entrada = Fecha_entrada;
            fkid_usuario = Fkid_usuario;
            fkid_proveedor = Fkid_proveedor;
        }

        public int id_entrada { get; set; }
        public string fecha_entrada { get; set; }
        public int fkid_usuario { get; set; }
        public int fkid_proveedor { get; set; }
    }
}
