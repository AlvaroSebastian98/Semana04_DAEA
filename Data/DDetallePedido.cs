using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos (DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<DetallePedido> detallesPedido = null;

            try
            {
                comandText = "USP_ListarDetalle";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.IdPedido;
                detallesPedido = new List<DetallePedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "USP_ListarDetalle",
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallesPedido.Add(new DetallePedido
                        {
                            IdPedido = reader["IdPedido"] != null ? Convert.ToInt32(reader["IdPedido"]) : 0,
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToInt32(reader["PrecioUnidad"]) : 0,
                            Cantidad = reader["Cantidad"] != null ? Convert.ToInt32(reader["Cantidad"]) : 0,
                            Descuento = reader["Descuento"] != null ? Convert.ToInt32(reader["Descuento"]) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detallesPedido;
        }
    }
}
