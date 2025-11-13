using AccesoDatos;
using Entidades;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;

public class ManejadorDetalleEntradas
{
    Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);
    public void ActualizarCantidad(int idDetalle, int nuevaCantidad)
    {
        string query = $"UPDATE detalle_entradas SET cantidad_entrada = {nuevaCantidad} WHERE id_detalleEntrada = {idDetalle};";
        b.Comando(query);
    }

    public void GuardarDetalle(List<DetalleEntradas> lista)
    {
        foreach (var detalle in lista)
        {
            try
            {
                string query = $"CALL p_InsertarDetalleEntrada({detalle.precio_entrada}, {detalle.cantidad_entrada}, {detalle.fkid_producto}, {detalle.fkid_entrada});";
                b.Comando(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar detalle de entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public int ObtenerSiguienteIdDetalle(int idProducto)
    {
        try
        {
            string query = $"SELECT IFNULL(max_id_detalle, 0) + 1 AS siguiente FROM v_MaxDetallePorProducto WHERE fkid_producto = {idProducto};";
            DataSet ds = b.Consulta(query, "detalle_entradas");
            return Convert.ToInt32(ds.Tables[0].Rows[0]["siguiente"]);
        }
        catch (Exception ex)
        {
            return 1;
        }
    }

    // Solo actualiza la cantidad, no devuelve nada
    public void ActualizarCantidadDetalle(int idDetalleEntrada, int nuevaCantidad)
    {
        try
        {
            string query = $"CALL p_ActualizarCantidadDetalle({idDetalleEntrada}, {nuevaCantidad});";
            b.Comando(query);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar cantidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
