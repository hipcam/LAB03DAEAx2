using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase03_DAEA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        ClsDatos obj = new ClsDatos();
        ClsDatos2 c = new ClsDatos2();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            c.ListarYear(cboYear);
        }

        private void cboYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            c.ListarMeses(cboMes, Convert.ToInt32(cboYear.SelectedValue));
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            c.ListarxEmpleado(cboEmp, Convert.ToInt32(cboYear.SelectedValue),
                Convert.ToInt32(cboMes.SelectedValue));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(cboYear.SelectedValue);
            int mes = Convert.ToInt32(cboMes.SelectedValue);
            int idemp = Convert.ToInt32(cboEmp.SelectedValue);
            dgvClientes.DataSource = c.ListarClientes(year, mes, idemp);
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 ID = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["NroPedido"].Value);
            dgvDetalle.DataSource = obj.ListaDetalle(ID);
            
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = Convert.ToString(dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value);
            int year = Convert.ToInt32(cboYear.SelectedValue);
            int mes = Convert.ToInt32(cboMes.SelectedValue);
            int idemp = Convert.ToInt32(cboEmp.SelectedValue);

            dgvPedidos.DataSource = c.ListarPedidoxCliente(ID, mes, idemp, year);
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int x;
                x = Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value);
                dgvDetalle.DataSource = obj.ListaDetalle(x);
                txtMontoTotal.Text = obj.PedidoTotal(x).ToString("c");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtPedidos.Text = Convert.ToString(dgvPedidos.Rows.Count);
            txtPedidos.Text = this.dgvPedidos.Rows.Count.ToString();


        }
    }
}
