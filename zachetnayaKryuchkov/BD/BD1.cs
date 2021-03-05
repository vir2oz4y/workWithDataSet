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
    public partial class BD1 : Form
    {
        private DataSet reports;
        DataView tovar;
        DataView postavshik;
        public BD1(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD1_Load(object sender, EventArgs e)
        {
            tovar = new DataView(reports.Tables["Tovar"]);
            postavshik = new DataView(reports.Tables["BD1"]);

            comboBox1.ValueMember = "KT";
            comboBox1.DisplayMember = "NaimT";

            listBox1.DisplayMember = "NaimP";

            listBox1.DataSource = postavshik;
            comboBox1.DataSource = tovar;

            postavshik.RowFilter = "parent(postTovar).KT=" + comboBox1.SelectedValue;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                postavshik.RowFilter = "parent(postTovar).KT=" + comboBox1.SelectedValue;
            }
        }
    }
}
