using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.IO;

namespace TPVTAC_WPF.DBModule
{
    class LogError
    {
        #region Propiedades Globales
        private String _ErrorCode     = String.Empty;
        private String _ErrorMessage  = String.Empty;
        private String _ErrorDesc     = String.Empty;
        private String _ErrorModule   = String.Empty;
        private String _ErrorType     = String.Empty;

        public String ErrorCode
        {
            set { _ErrorCode = value; }
            get { return _ErrorCode; }
        }

        public String ErrorMessage
        {
            set { _ErrorMessage = value; }
            get { return _ErrorMessage; }
        }

        public String ErrorDesc
        {
            set { _ErrorDesc = value; }
            get { return _ErrorDesc; }
        }

        public String ErrorModule
        {
            set { _ErrorModule = value; }
            get { return _ErrorModule; }
        }

        public String ErrorType
        {
            set { _ErrorType = value; }
            get { return _ErrorType; }
        }
        #endregion

        public void LogTxt()
        {
            String pathtxt = System.Configuration.ConfigurationManager.AppSettings["PathLogTexto"] + DateTime.Now.ToString("yyyy-MM-dd") + "LogErrror.txt";
            StreamWriter sw = new StreamWriter(pathtxt, true, System.Text.Encoding.Default);
            try 
            {
                sw.NewLine.Insert(0, "");
                sw.WriteLine("-----------------------------------------------------");
                sw.WriteLine("{0,-15} {1}", "Fecha:", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                sw.WriteLine("{0,-15} {1}", "Modulo:", _ErrorModule);
                sw.WriteLine("{0,-15} {1}", "Descripcion:", _ErrorMessage);
                sw.AutoFlush = true;
                sw.Close();
            
            }
            catch(Exception ex)
            {
                _ErrorMessage = ex.Message;
            }    
        }

    }
}
