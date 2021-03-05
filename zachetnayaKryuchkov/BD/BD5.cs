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
    public partial class BD5 : Form
    {
        private DataSet reports;
        DataView sotr;
        DataView count;
        public BD5(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD5_Load(object sender, EventArgs e)
        {
            sotr = new DataView(reports.Tables["Sotrudniki"]);
            count = new DataView(reports.Tables["BD5"]);

            comboBox1.ValueMember = "KS";
            comboBox1.DisplayMember = "fam";
            comboBox1.DataSource = sotr;

            textBox1.DataBindings.Add("Text" ,count,"kol_vo");

            count.RowFilter = "parent(sotrCount).KS=" + comboBox1.SelectedValue;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                count.RowFilter = "parent(sotrCount).KS=" + comboBox1.SelectedValue;
            }
        }

        private void ComboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            DataRowView row = e.ListItem as DataRowView;
            e.Value = row["fam"] + " " + row["im"] + " " + row["otch"];
        }
    }
}
