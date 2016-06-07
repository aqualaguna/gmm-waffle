using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
namespace RLIB
{
    public class Connection
    {
        public OracleConnection c;
        string host = "";
        public string ConString
        {
            get { return host; }
            set { host = value; }
        }
        public Connection() { }
        public void connCall(string uname,string pass) {
            try
            {
                c = new OracleConnection();
                c.ConnectionString = host+"user id ="+uname+";password="+pass+";";
                if (c.State == System.Data.ConnectionState.Open) { c.Close(); }
                c.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
