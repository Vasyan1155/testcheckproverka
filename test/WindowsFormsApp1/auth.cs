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

namespace WindowsFormsApp1
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            string pass = textBox2.Text;
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user225_db;persist security info=True;user id=user225_db;password=user225;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection con = new SqlConnection(connect);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"Select pass, login from Klient_E where login = '{login}' and pass = '{pass}'";

            SqlCommand log = new SqlCommand(query, con);

            adapter.SelectCommand = log;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы вошли!");
                Form client = new Client();
                client.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Упс! такого пользователя не существует!");
            }
        }

    }
}
