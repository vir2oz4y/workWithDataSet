using System;
using System.Data;
using System.Windows.Forms;
using zachetnayaKryuchkov.Postavshik;
using zachetnayaKryuchkov.Sklad;
using zachetnayaKryuchkov.Sotrudnik;
using zachetnayaKryuchkov.Tovar;

namespace zachetnayaKryuchkov
{
    public partial class InfoTables : Form
    {
        private DataSet tables;
        public InfoTables(DataSet table)
        {
            InitializeComponent();
            tables = table;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TovarTable tovarTable = new TovarTable(tables);
            tovarTable.ShowDialog();
        }

        private void InfoTables_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PostavshikTable postavshikTable = new PostavshikTable(tables);
            postavshikTable.ShowDialog(); 
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SotrudnikTable sotrudnikTable = new SotrudnikTable(tables);
            sotrudnikTable.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SkladTable skladTable = new SkladTable(tables);
            skladTable.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
