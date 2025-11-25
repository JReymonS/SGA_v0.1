using AccesoDatos;
using Entidades;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace Manejadores
{
    public class ManejadorLogin
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");


        //METODO PARA VALIDAR LOGIN Y RECUPERAR PERMISOS
        public (bool Acceso, string Mensaje, Usuarios UsuarioEncontrado, Roles RolPerteneciente) ValidarLogin(string usuario, string contrasena) 
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena)) 
            {
                return (false, "Por favor complete todos los campos.", null,null);
            }

            DataSet ds = b.Consulta($"SELECT * FROM v_UsuariosRolPermisos WHERE BINARY NombreUsuario like '%{usuario}%' AND Clave like '%{Sha1(contrasena)}%'", "v_UsuariosRolPermisos");
            if (ds.Tables.Count >0 && ds.Tables[0].Rows.Count >=1)
            {
                DataTable dt = ds.Tables[0];
                Usuarios user = new Usuarios(0,"","","","","",0);
                Roles rol = new Roles(0,"","","");

                foreach (DataRow row in dt.Rows) 
                {
                    if (user.id_usuario == 0) 
                    {
                        user.id_usuario = Convert.ToInt32(row["IdUsuario"]);
                        user.nombre = row["NombreUsuario"].ToString();
                        user.fkid_rol = Convert.ToInt32(row["IdRol"]);
                    }

                    Permisos permisos = new Permisos
                    (
                        Convert.ToInt32(row["IdPermiso"]),
                        Convert.ToString(row["PermisoCrear"]),
                        Convert.ToString(row["PermisoLeer"]),
                        Convert.ToString(row["PermisoModificar"]),
                        Convert.ToString(row["PermisoEliminar"]),
                        Convert.ToInt32(row["IdRol"]),
                        Convert.ToInt32(row["IdModulo"])

                    );
                    rol.permisos.Add(permisos);
                }
                return(true, "Acceso concedido.", user, rol);
            }
            else 
            {
                return (false, "Usuario o contraseña incorrectos.", null,null);
            }

        }


        //METODO PARA MOSTRAR CONTRASEÑA O OCULTARLA
        public void MostrarOcultarContrasena(TextBox caja, bool mostrar)
        {
            if (mostrar)
            {
                caja.PasswordChar = '\0';
            }
            else
            {
                caja.PasswordChar = '*';
            }
        }


        //METODO PARA LIMPIAR CAJAS DE TEXTO
        public void LimipiarCajas(TextBox caja1, TextBox caja2)
        {
            caja1.Clear();
            caja2.Clear();
        }


        //METODO PARA ENCRIPTADO DE CONTRASEÑA
        public static string Sha1(string texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();

            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
    }
}
