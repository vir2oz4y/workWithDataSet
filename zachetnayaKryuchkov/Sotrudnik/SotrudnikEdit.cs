using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov.Sotrudnik
{
    public partial class SotrudnikEdit : Form
    {
        private DataTable data;
        private object[] newRow;
        int index;
        List<string> Pol;
        public SotrudnikEdit(DataTable dataTable)
        {
            InitializeComponent();
            data = dataTable;
        }

        public SotrudnikEdit(DataTable dataTable, DataRow dRow, int ind)
        {
            InitializeComponent();
            data = dataTable;
            index = ind;
            newRow = dRow.ItemArray;
        }

        private void SotrudnikEdit_Load(object sender, EventArgs e)
        {
            Pol = new List<string>() { "Мужской", "Женский" };
            listBox1.DataSource = Pol;


            if (newRow != null)
            {
                textBox1.Text = newRow[1].ToString();
                textBox2.Text = newRow[2].ToString();
                textBox3.Text = newRow[3].ToString();
                dateTimePicker1.Value = DateTime.Parse(newRow[4].ToString());
                listBox1.SelectedIndex = CheckPol(newRow[5].ToString());
                textBox4.Text = newRow[6].ToString();
            }
        }


        private int CheckPol(string pol)
        {
            if ( pol == "Мужской")
            {
                return 0;
            }
            return 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (newRow != null)
            {
                SqlHelper.UpdateDataTable(ref data, index,
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    dateTimePicker1.Value.ToString(),
                    listBox1.SelectedItem.ToString(),
                    textBox4.Text
                    );
            }
            else
            {
                SqlHelper.InsertIntoDataTable("KS", ref data, 
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    dateTimePicker1.Value.ToString(),
                    listBox1.SelectedItem.ToString(),
                    textBox4.Text
                    );
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
