using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            string pass = textBox2.Text;
            string phone = textBox3.Text;
            string name = textBox4.Text;
            string adres = textBox5.Text;
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user225_db;persist security info=True;user id=user225_db;password=user225;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection con = new SqlConnection(connect);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"insert into Klient_E (id_klienta,name, adres, telefon, login, pass) " +
                $"values ((SELECT ISNULL(MAX(id_klienta) + 1,0) FROM Klient_E), '{name}', '{adres}','{phone}','{login}','{pass}') ";

            SqlCommand reg = new SqlCommand(query, con);

            
            con.Open();
            if(reg.ExecuteNonQuery() != 0 ) {
                MessageBox.Show("Аккаунт успешно создан!");
                this.Close();
                Form log = new auth();
                log.ShowDialog();
                con.Close();
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '+'))
            {
                e.Handled = true;

            }
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }
    }
}
