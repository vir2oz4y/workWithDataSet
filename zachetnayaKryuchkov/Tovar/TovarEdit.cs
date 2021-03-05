using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov.Tovar
{
    public partial class TovarEdit : Form
    {
        private DataTable data;
        private object[] newRow;
        int index;
        public TovarEdit(DataTable dataTable)
        {
            InitializeComponent();
            data = dataTable;
        }

        public TovarEdit(DataTable dataTable, DataRow dRow, int ind)
        {
            InitializeComponent();
            data = dataTable;
            index = ind;
            newRow = dRow.ItemArray;
        }
        
        private void TovarEdit_Load(object sender, EventArgs e)
        {
            if (newRow != null)
            {
                textBox1.Text = newRow[1].ToString();
                numericUpDown1.Value =Decimal.Parse(newRow[2].ToString());
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            if (newRow!=null)
            {
                SqlHelper.UpdateDataTable(ref data, index,
                    textBox1.Text,
                    numericUpDown1.Value.ToString()
                    );
            }
            else
            {
                SqlHelper.InsertIntoDataTable("KT", ref data,
                    textBox1.Text,
                    numericUpDown1.Value.ToString()
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
