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
    public partial class BD4 : Form
    {
        private DataSet reports;
        DataView tovar;
        public BD4(DataSet dataSet)
        {
            InitializeComponent();
            reports = dataSet;
        }

        private void BD4_Load(object sender, EventArgs e)
        {
            tovar = new DataView(reports.Tables["BD4"]);

            listBox1.DisplayMember = "NaimT";
            listBox1.DataSource = tovar;
        }
    }
}
