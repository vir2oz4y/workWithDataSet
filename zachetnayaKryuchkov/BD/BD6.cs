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
    public partial class BD6 : Form
    {
        private DataSet reports;
        DataView post;
        DataView summa;
        public BD6(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD6_Load(object sender, EventArgs e)
        {
            post = new DataView(reports.Tables["Postavshiki"]);
            summa = new DataView(reports.Tables["BD6"]);

            comboBox1.ValueMember = "KP";
            comboBox1.DisplayMember = "naimP";
            comboBox1.DataSource = post;

            textBox1.DataBindings.Add("Text", summa, "vsego");

            summa.RowFilter = "parent(postSum).KP=" + comboBox1.SelectedValue;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                summa.RowFilter = "parent(postSum).KP=" + comboBox1.SelectedValue;
            }
        }
    }
}
