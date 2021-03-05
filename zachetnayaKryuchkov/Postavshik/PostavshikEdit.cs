using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov.Postavshik
{
    public partial class PostavshikEdit : Form
    {
        private DataTable data;
        private object[] newRow;
        int index;
        public PostavshikEdit(DataTable dataTable)
        {
            InitializeComponent();
            data = dataTable;
        }

        public PostavshikEdit(DataTable dataTable, DataRow dRow, int ind)
        {
            InitializeComponent();
            data = dataTable;
            index = ind;
            newRow = dRow.ItemArray;
        }


        private void PostavshikEdit_Load(object sender, EventArgs e)
        {
            if (newRow != null)
            {
                textBox1.Text = newRow[1].ToString();
                textBox2.Text = newRow[2].ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (newRow != null)
            {
                SqlHelper.UpdateDataTable(ref data, index,
                    textBox1.Text,
                    textBox2.Text
                    );
            }
            else
            {
                SqlHelper.InsertIntoDataTable("KP", ref data,
                    textBox1.Text,
                    textBox2.Text
                    );
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
