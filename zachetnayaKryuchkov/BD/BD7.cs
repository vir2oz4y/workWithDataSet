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
    public partial class BD7 : Form
    {
        private DataSet reports;
        DataView post;
        public BD7(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD7_Load(object sender, EventArgs e)
        {
            post = new DataView(reports.Tables["BD7"]);

            dataGridView1.DataSource = post;
        }
    }
}
