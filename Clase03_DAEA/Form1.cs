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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        ClsDatos obj = new ClsDatos();
        private void button1_Click(object sender, EventArgs e)
        {
            dgvPedidos.DataSource = obj.ListaPedidoFecha(Convert.ToDateTime(dateTimePicker1.Value),
                Convert.ToDateTime(dateTimePicker2.Value));
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int x;
                x = Convert.ToInt32(dgvPedidos.CurrentRow.Cells[0].Value);
                dgvDetalles.DataSource = obj.ListaDetalle(x);
                txtTotal.Text = obj.PedidoTotal(x).ToString("c");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
