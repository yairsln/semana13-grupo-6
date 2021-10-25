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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server =127.0.0.1;  port = 3306; database =dias; uid =root; password=;");
            conectar.Open();


            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("select *from login where usuario = ' " +txtusu.Text+ "' and pass = '" +txtpass.Text+ "'");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {

                MessageBox.Show("Bienvenido al sistema yair ", "login");
            }
            else
            {

                MessageBox.Show(" usuario o contraseña incorrecto", "login",MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conectar.Close();

        }
    }
}
