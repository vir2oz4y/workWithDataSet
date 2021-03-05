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
    public partial class BD3 : Form
    {
        private DataSet reports;
        DataView tovar;

        public BD3(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD3_Load(object sender, EventArgs e)
        {
            tovar = new DataView(reports.Tables["BD3"]);

            listBox1.DisplayMember = "NaimT";
            listBox1.DataSource = tovar;
        }
    }
}
