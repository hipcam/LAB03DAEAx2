using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Clase03_DAEA
{
    public class ClsDatos2
    {

        Conexion cn = new Conexion();
  
        public void ListarYear(ComboBox cbo)
        {
            SqlDataAdapter df = new SqlDataAdapter("Usp_ListarAno", cn.cadena());
            df.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            df.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = "Anno";
            cbo.ValueMember = "Anno";


        }
        public void ListarMeses(ComboBox cbo, int year)
        {
            SqlDataAdapter df = new SqlDataAdapter("Usp_ListarMes", cn.cadena());
            df.SelectCommand.CommandType = CommandType.StoredProcedure;
            df.SelectCommand.Parameters.AddWithValue("@idyear", year);
            DataTable dt = new DataTable();
            df.Fill(dt);

            cbo.DataSource = dt;
            cbo.DisplayMember = "Meses";
            cbo.ValueMember = "orden";


        }
        public void ListarxEmpleado(ComboBox cbo, int year, int meses)
        {
            SqlDataAdapter df = new SqlDataAdapter("Usp_ListarxEmpleado", cn.cadena());
            df.SelectCommand.CommandType = CommandType.StoredProcedure;
            df.SelectCommand.Parameters.AddWithValue("@idyear", year);
            df.SelectCommand.Parameters.AddWithValue("@idmes", meses);
            DataTable dt = new DataTable();
            df.Fill(dt);

            cbo.DataSource = dt;
            cbo.DisplayMember = "Nombre";
            cbo.ValueMember = "Empleados.IdEmpleado";
        }
        public DataTable ListarClientes(int year, int mes, int idemp)
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListarClientes", cn.cadena()))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                df.SelectCommand.Parameters.AddWithValue("@idyear", year);
                df.SelectCommand.Parameters.AddWithValue("@idmes", mes);
                df.SelectCommand.Parameters.AddWithValue("@idemp", idemp);
                using (DataTable dt = new DataTable())
                {
                    df.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ListarPedidoxCliente(string cli, int mes, int idemp, int year)
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListarPedidoxCliente ", cn.cadena()))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                df.SelectCommand.Parameters.AddWithValue("@idcli", cli);
                df.SelectCommand.Parameters.AddWithValue("@idmes", mes);
                df.SelectCommand.Parameters.AddWithValue("@idemp", idemp);
                df.SelectCommand.Parameters.AddWithValue("@idyear", year);
                using (DataTable dt = new DataTable())
                {
                    df.Fill(dt);
                    return dt;
                }
            }

        }
      

    }
}
