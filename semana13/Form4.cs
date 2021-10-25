using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace semana13
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=dias; uid=root; password=;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectamos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("select * from login where  usuario = '" + txtusuario.Text + "' and pass = '" + txtpass.Text +" ' ");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                MessageBox.Show(" bienvenido al sistema yair  ", " login");
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show(" Usuario o Contrseña Incorrecta ", "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conectar.Close();
        }
    }
}
