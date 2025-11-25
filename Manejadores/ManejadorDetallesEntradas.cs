using AccesoDatos;
using Entidades;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;

public class ManejadorDetalleEntradas
{
    Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);

    //METODO PARA ACTUALIZAR LA CANTIDAD EN PRODUCTO REGISTRADO
    public void ActualizarCantidad(int idDetalle, int nuevaCantidad)
    {
        string query = $"UPDATE detalle_entradas SET cantidad_entrada = {nuevaCantidad} WHERE id_detalleEntrada = {idDetalle};";
        b.Comando(query);
    }


    //METODO PARA GUARDAR DETALLES DE ENTRADAS
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
                MessageBox.Show($"Error al guardar detalle de entrada: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    //METODO PARA ACTUALIZAR COSTO DE DETALLES DE ENTRADAS
    public void ActualizarCostoDetalle(int idDetalleEntrada, double nuevoCosto)
    {
        try
        {
            string query = $"CALL p_ActualizarCostoDetalle({idDetalleEntrada}, {nuevoCosto});";
            b.Comando(query);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar costo: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    //METODO PARA OBTENER EL SIGUIENTE DETALLE DE ENTRADAS
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


    //METODO PARA ACTUALIZAR LA CANTIDAD EN DETALLES DE ENTRADAS
    public void ActualizarCantidadDetalle(int idDetalleEntrada, int nuevaCantidad)
    {
        try
        {
            string query = $"CALL p_ActualizarCantidadDetalle({idDetalleEntrada}, {nuevaCantidad});";
            b.Comando(query);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar cantidad: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
