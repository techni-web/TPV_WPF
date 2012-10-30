using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace TPVTAC_WPF
{
    class dbZonas
    {
        #region Variables Globales
        private String _sqlConexion = System.Configuration.ConfigurationManager.AppSettings["conexion"].ToString();
        #endregion

        #region Propiedades Globales
        private String _ErrorMesage = String.Empty;
        private String _Query = String.Empty;

        #region Clases Globales
        private DBModule.db _db = new DBModule.db();
        #endregion

        public String ErrorMessage
        {
            set { _ErrorMesage = value; }
            get { return _ErrorMesage; }
        }
        #endregion

        #region Gets

        public Boolean getZonas(out DataTable dt)
        {
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT [500ID], [500NOMBRE] FROM T500_ZONAS ORDER BY [500ORDEN] ASC");
            _Query = sb.ToString();
            
            if(!_db.SqlExcecuteQuery(_sqlConexion,_Query,ref dt,30))
            {
                _ErrorMesage = _db._dbError;
            }

            return true;
        }

        public Boolean getMesasporZonas(string zonaId, out DataTable dt)
        {
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT [501ID], [501NOMBRE], [501POS_X], [501POS_Y], [501ANCHO], [501ALTO] " +
                      "FROM T501_MESAS WHERE [501ZONA] = " + zonaId);
            _Query = sb.ToString();

            if (!_db.SqlExcecuteQuery(_sqlConexion, _Query, ref dt, 30))
            {
                _ErrorMesage = _db._dbError;
            }

            return true;
        }

        #endregion
    }
}
