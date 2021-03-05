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
    public partial class SkladTable : Form
    {
        BindingSource tovar;
        BindingSource postavshik;
        BindingSource sotrundik;
        BindingSource sklad;

        private DataTable dataTable;
        private DataSet dataSet;

        public SkladTable(DataSet Set)
        {
            InitializeComponent();
            dataSet = Set;
            dataTable = dataSet.Tables["Sklad"];

            sklad = new BindingSource { DataSource = dataSet.Tables["Sklad"] };
            tovar = new BindingSource { DataSource = dataSet.Tables["Tovar"] };
            postavshik = new BindingSource { DataSource = dataSet.Tables["Postavshiki"] };
            sotrundik = new BindingSource { DataSource = dataSet.Tables["Sotrudniki"] };
        }

        private void SkladTable_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Fam";
            listBox1.ValueMember = "ks";

            listBox2.DisplayMember = "NaimP";
            listBox2.ValueMember = "KP";

            listBox3.DisplayMember = "NaimT";
            listBox3.ValueMember = "KT";

            listBox1.DataSource = sotrundik;
            listBox2.DataSource = postavshik;
            listBox3.DataSource = tovar;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = sklad;
            dataGridView1.Columns.Add("data", "дата");
            dataGridView1.Columns.Add("obiem", "объем");
            dataGridView1.Columns.Add("stoim", "стоимость");
            dataGridView1.Columns["data"].DataPropertyName = "dataP";
            dataGridView1.Columns["obiem"].DataPropertyName = "Obiem";
            dataGridView1.Columns["stoim"].DataPropertyName = "Stoim";
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sklad.Filter = string.Format("ks = {0} and kp = {1} and kt = {2}",
                (int)listBox1.SelectedValue,
                (int)listBox2.SelectedValue,
                (int)listBox3.SelectedValue
                );
            }
            catch 
            {

            }
            
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sklad.Filter = string.Format("ks = {0} and kp = {1} and kt = {2}",
                (int)listBox1.SelectedValue,
                (int)listBox2.SelectedValue,
                (int)listBox3.SelectedValue
                );
            }
            catch
            {

            }
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sklad.Filter = string.Format("ks = {0} and kp = {1} and kt = {2}",
                (int)listBox1.SelectedValue,
                (int)listBox2.SelectedValue,
                (int)listBox3.SelectedValue
                );
            }
            catch
            {

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            sklad.RemoveCurrent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> KS = new KeyValuePair<int, string>((int)listBox1.SelectedValue, listBox1.Text);
            KeyValuePair<int, string> KP = new KeyValuePair<int, string>((int)listBox2.SelectedValue, listBox2.Text);
            KeyValuePair<int, string> KT = new KeyValuePair<int, string>((int)listBox3.SelectedValue, listBox3.Text);

            SkladEdit skladEdit = new SkladEdit(dataTable, KS, KT, KP, false);
            skladEdit.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> KS = new KeyValuePair<int, string>((int)listBox1.SelectedValue, listBox1.Text);
            KeyValuePair<int, string> KP = new KeyValuePair<int, string>((int)listBox2.SelectedValue, listBox2.Text);
            KeyValuePair<int, string> KT = new KeyValuePair<int, string>((int)listBox3.SelectedValue, listBox3.Text);

            SkladEdit skladEdit = new SkladEdit(dataTable, KS, KT, KP, true);
            skladEdit.ShowDialog();
        }
    }
}
