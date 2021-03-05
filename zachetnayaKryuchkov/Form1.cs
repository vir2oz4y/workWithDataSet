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
using zachetnayaKryuchkov.BD;

namespace zachetnayaKryuchkov
{
    public partial class Form1 : Form
    {
        SqlAdapterFill sql;
        private DataSet tables;
        private DataSet reports;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SKLADConnectionString);
            try
            {
                connection.Open();
                sql = new SqlAdapterFill();

                tables = sql.Tables();

                reports = sql.DB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            InfoTables infoTables = new InfoTables(tables);
            infoTables.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result =  SqlHelper.SaveToDataBase(tables, sql);
            if (result == DialogResult.Yes)
            {
                e.Cancel = true;
                tables = sql.Tables();
                reports = sql.DB();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BDmain bDmain = new BDmain(reports);
            bDmain.ShowDialog();
        }
    }
}
