using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace RLIB
{
    public class Master
    {
        public Connection conn;
        private List<string> param;
        private List<condition> wh;
        private List<condition> set;

        public Master(Connection c)
        {
            param = new List<string>();
            wh = new List<condition>();
            set = new List<condition>();
            conn = c;
        }

        public void addParamStr(string t)
        {
            param.Add(toSqlString(t));
        }
        public void addCondition(condition a)
        {
            wh.Add(a);
        }

        public void addSet(condition a)
        {
            if (a.op == opCondition.eq)
            {
                a.op = opCondition.eq;
                set.Add(a);
            }
        }

        public void addParamNumber(string t)
        {
            param.Add(t);
        }

        public void addParamDate(string t, string format)
        {
            param.Add("TO_DATE(" + toSqlString(t) + "," + toSqlString(format) + ")");
        }
        public void clearParam()
        {
            param.Clear();
            set.Clear();
            wh.Clear();
        }
        public static string toSqlString(string t)
        {
            return "'" + t + "'";
        }

        public void insert(string table)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn.c;
                string temp = "insert into " + table + " values(";
                bool first = true;
                foreach (string i in param)
                {
                    if (!first) temp += ",";
                    first = false;
                    temp += i;
                }
                cmd.CommandText = temp + ")";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clearParam();
            }
        }
        public void update(string table)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn.c;
                string temp = "update " + table + " set ";
                bool flag = true;
                foreach (condition i in set)
                {
                    if (!flag) temp += ",";
                    flag = false;
                    temp += i.toString();
                }
                temp += " where ";
                foreach (condition i in wh)
                {
                    temp += i.toString();
                }
                cmd.CommandText = temp;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                clearParam();
            }
        }

        public string callProcedure(string namaProc, string namaBar)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT " + namaProc + "(" + Master.toSqlString(namaBar) + ") from dual";
                cmd.Connection = conn.c;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    return rdr[0].ToString();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void test()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM BARANG",conn.c);

            OracleCommandBuilder cb = new OracleCommandBuilder(da);
            Console.WriteLine();
            Console.WriteLine(cb.GetInsertCommand().CommandText);
            Console.WriteLine();
            Console.WriteLine(cb.GetUpdateCommand().CommandText);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(cb.GetDeleteCommand().CommandText);
            Console.WriteLine();
            //OracleCommand cmd = cb.GetInsertCommand();
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add(1);
            //cmd.Parameters.Add("aku");
            //cmd.Parameters.Add(2);
            //cmd.Parameters.Add(1);
            //cmd.ExecuteNonQuery();
        }
        public void delBarang(string table,string kode)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn.c;
                string temp = "delete from "+table+" where kode_barang = '" + kode + "'";
                cmd.CommandText = temp;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clearParam();
            }
        }
    }
}
