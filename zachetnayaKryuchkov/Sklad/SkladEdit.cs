using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov.Sklad
{
    public partial class SkladEdit : Form
    {
        private KeyValuePair<int, string> KS;
        private KeyValuePair<int, string> KT;
        private KeyValuePair<int, string> KP;
        private bool isAdd;
        private DataTable dataTable;
        private List<SkladElement> skladElements;
        private int index;
        public SkladEdit(
            DataTable data,
            KeyValuePair<int, string> ks,
            KeyValuePair<int, string> kt,
            KeyValuePair<int, string> kp,
            bool enable
            )
        {
            InitializeComponent();
            dataTable = data;
            KS = ks;
            KT = kt;
            KP = kp;
            isAdd = enable;

            if (isAdd)
            {
                dataGridView1.Enabled = false;
            }

        }

        private void SkladEdit_Load(object sender, EventArgs e)
        {
            comboBox1.Text = KS.Value;
            comboBox2.Text = KP.Value;
            comboBox3.Text = KT.Value;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns.Add("data", "дата");
            dataGridView1.Columns.Add("obiem", "объем");
            dataGridView1.Columns.Add("stoim", "стоимость");
            dataGridView1.Columns["data"].DataPropertyName = "dataP";
            dataGridView1.Columns["obiem"].DataPropertyName = "Obiem";
            dataGridView1.Columns["stoim"].DataPropertyName = "Stoim";

            AddToSkladElement();
        }

        private void AddToSkladElement()
        {
            skladElements = new List<SkladElement>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                skladElements.Add(new SkladElement(dataGridView1.Rows[i]));
            }
        }

        private void RollBack()
        {
            for (int i = 0; i < skladElements.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = DateTime.Parse(skladElements[i].date);
                dataGridView1.Rows[i].Cells[1].Value = skladElements[i].obiem;
                dataGridView1.Rows[i].Cells[2].Value = skladElements[i].stoim;
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                numericUpDown1.Value = Decimal.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString());
                numericUpDown2.Value = Decimal.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
            }
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            RollBack();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled)
            {
                dataGridView1.Rows[index].Cells[1].Value = numericUpDown1.Value;
            }
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled)
            {
                dataGridView1.Rows[index].Cells[2].Value = numericUpDown2.Value;
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled)
            {
                dataGridView1.Rows[index].Cells[0].Value = dateTimePicker1.Value.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Enabled)
            {
                SqlHelper.InsertIntoDataTable(ref dataTable, 
                    dateTimePicker1.Value.ToString("dd.MM.yyyy"),
                    numericUpDown1.Value.ToString(),
                     numericUpDown2.Value.ToString(),
                     KT.Key.ToString(),
                     KP.Key.ToString(),
                     KS.Key.ToString()
                    );
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
