using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov.BD
{
    public partial class BD2 : Form
    {
        private DataSet reports;
        DataView tovar;
        DataView sotrudnik;
        public BD2(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD2_Load(object sender, EventArgs e)
        {
            tovar = new DataView(reports.Tables["Tovar"]);
            sotrudnik = new DataView(reports.Tables["BD2"]);

            comboBox1.ValueMember = "KT";
            comboBox1.DisplayMember = "NaimT";

            listBox1.DisplayMember = "fam";

            listBox1.DataSource = sotrudnik;
            comboBox1.DataSource = tovar;

            sotrudnik.RowFilter = "parent(tovarSotr).KT=" + comboBox1.SelectedValue;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                sotrudnik.RowFilter = "parent(tovarSotr).KT=" + comboBox1.SelectedValue;
            }
        }
    }
}
