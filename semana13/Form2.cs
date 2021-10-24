using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace semana13
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        static string conexion = "server =127.0.0.1; port = 3306; database = dias; uid = root; password = ;";
        MySqlConnection cn = new MySqlConnection(conexion);

        public DataTable llenar_grid() 
        {
            cn.Open();
            DataTable dt = new DataTable();
            string llenar = "select * from inventario";
            MySqlCommand cmd = new MySqlCommand(llenar,cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
            return dt;
        
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenar_grid();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Focus();
            button1.Visible = false;
            button2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            string guardar = "insert into inventario (codigo,proveedor,producto,unidad,costo,cantidad,valor) values (@codigo,@proveedor,@producto,@unidad,@costo,@cantidad,@valor)";
            MySqlCommand cmd = new MySqlCommand(guardar,cn);
            cmd.Parameters.AddWithValue("@codigo",textBox1.Text);
            cmd.Parameters.AddWithValue("@proveedor", textBox2.Text);
            cmd.Parameters.AddWithValue("@producto", textBox3.Text);
            cmd.Parameters.AddWithValue("@unidad", textBox4.Text);
            cmd.Parameters.AddWithValue("@costo", textBox5.Text);
            cmd.Parameters.AddWithValue("@cantidad", textBox6.Text);
            cmd.Parameters.AddWithValue("@valor", textBox7.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Datos guardados", "guardar",MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = llenar_grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();
            string actualizar = " update inventario set codigo=@codigo, proveedor=@proveedor, producto=@producto, unidad=@unidad, costo=@costo, cantidad=@cantidad, valor=@valor where codigo=@codigo";
            MySqlCommand cmd = new MySqlCommand(actualizar,cn);
            cmd.Parameters.AddWithValue("@codigo", textBox1.Text);
            cmd.Parameters.AddWithValue("@proveedor", textBox2.Text);
            cmd.Parameters.AddWithValue("@producto", textBox3.Text);
            cmd.Parameters.AddWithValue("@unidad", textBox4.Text);
            cmd.Parameters.AddWithValue("@costo", textBox5.Text);
            cmd.Parameters.AddWithValue("@cantidad", textBox6.Text);
            cmd.Parameters.AddWithValue("@valor", textBox7.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Datos modificados con exito", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = llenar_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            }
            catch
            {


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            string eliminar = " delete from inventario where codigo=@codigo";
            MySqlCommand cmd = new MySqlCommand(eliminar,cn);
            cmd.Parameters.AddWithValue("@codigo", textBox1.Text);
            cmd.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Datos eliminados con exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = llenar_grid();
            button1.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();


        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
        }
    }
}
