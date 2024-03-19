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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            createColumns();
            openZak(dataGridView1);
        }
        private void createColumns()
        {
            dataGridView1.Columns.Add("id_zakaza", "Номер");
            dataGridView1.Columns.Add("kolichestvo", "Кол-во");
            dataGridView1.Columns.Add("name", "Название");
        }
        private void ReadColumn(DataGridView drg, IDataRecord record)
        {
            drg.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2));
        }

        private void openZak(DataGridView drg)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user225_db;persist security info=True;user id=user225_db;password=user225;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection con = new SqlConnection(connect);

            drg.Rows.Clear();
            string query = $"select Zakaz_E.id_zakaza, Zakaz_E.kolichestvo, tovar_E.name from Zakaz_E join tovar_E on Zakaz_E.id_tovar = tovar_E.id_tovar";
            SqlCommand ins = new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = ins.ExecuteReader();
            while (reader.Read())
            {
                ReadColumn(drg, reader);
            }
            reader .Close();
        }
    }
}
