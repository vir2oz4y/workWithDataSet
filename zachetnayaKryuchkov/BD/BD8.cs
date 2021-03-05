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
    public partial class BD8 : Form
    {
        private DataSet reports;
        DataView post;
        public BD8(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD8_Load(object sender, EventArgs e)
        {
            post = new DataView(reports.Tables["BD8"]);
            dataGridView1.DataSource = post;
            string x = string.Format("datap = '{0}'",dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            post.RowFilter = x;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            post.RowFilter = "datap = " + dateTimePicker1.Value;
        }
    }
}
