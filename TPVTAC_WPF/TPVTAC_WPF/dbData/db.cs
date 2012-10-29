using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace TPVTAC_WPF.DBModule
{
    
    class db
    {

        public String _dbError = String.Empty;

        public Boolean SqlExcecuteQuery(string Conexion, string Query, ref DataTable datos, int timeout)
        {
            try
            {
                SqlConnection oConexion = new SqlConnection(Conexion);
                SqlDataAdapter oDataAdapter = new SqlDataAdapter(Query, oConexion);
                SqlCommandBuilder oCommBuild = new SqlCommandBuilder(oDataAdapter);

                oConexion.Open();
                oDataAdapter.Fill(datos);
                oConexion.Close();

                return true;
            }
            catch (Exception ex)
            {
                _dbError = ex.Message;
                return false;
            }
        }
        
    }


}
