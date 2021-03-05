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
    public partial class SotrudnikTable : Form
    {
        private BindingSource bindingSource;
        private DataTable dataTable;
        public SotrudnikTable(DataSet table)
        {
            InitializeComponent();
            dataTable = table.Tables["Sotrudniki"];
            dataTable.Columns[0].AutoIncrement = true;
            //DataColumn computedColumn = new DataColumn("FIO", typeof(string));
            //computedColumn.Expression = "[Fam] + ' ' + [Im] + ' ' + [Otch]";
            //dataTable.Columns.Add(computedColumn);

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
        }

        private void SotrudnikTable_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Fam";
            listBox1.ValueMember = "ks";
            listBox1.DataSource = bindingSource;

            dateTimePicker1.DataBindings.Add(new Binding("Value", bindingSource, "DataR"));

            textBox1.DataBindings.Add("Text", bindingSource, "TelP");
            textBox2.DataBindings.Add("Text", bindingSource, "Pol");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SotrudnikEdit sotrEdit = new SotrudnikEdit(dataTable, dataTable.Rows[bindingSource.Position], bindingSource.Position);
            sotrEdit.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SotrudnikEdit sotrEdit = new SotrudnikEdit(dataTable);
            sotrEdit.ShowDialog();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int countChild = dataTable.Rows[bindingSource.Position].GetChildRows("SkladSotr").Length;
            SqlHelper.DeleteFromDataTable(ref dataTable, bindingSource.Position, countChild);
        }

        private void ListBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            DataRowView row = e.ListItem as DataRowView;
            e.Value = row["fam"] + " " + row["im"] + " " + row["otch"];
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
