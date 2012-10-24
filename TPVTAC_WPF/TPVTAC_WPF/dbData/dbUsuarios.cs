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
    class dbUsuarios
    {
        #region Variables Globales
        private String _sqlConexion = ConfigurationSettings.AppSettings["conexion"].ToString();
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

        public Boolean getUsuarios(out DataTable dt)
        {
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM USUARIO");
            _Query = sb.ToString();
            
            if(!_db.SqlExcecuteQuery(_sqlConexion,_Query,ref dt,30))
            {
                _ErrorMesage = _db._dbError;
            }

            return true;
        }


        public Boolean validaUsuario(string Usuario, out DataTable dt)
        {
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT PWD ");
            sb.Append("FROM USUARIO ");
            sb.Append("WHERE [NOMBRE_USUARIO] = '" + Usuario + "'");
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
