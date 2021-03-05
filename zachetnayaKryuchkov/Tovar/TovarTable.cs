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
    public partial class TovarTable : Form
    {
        private BindingSource bindingSource;
        private DataTable dataTable;

        public TovarTable(DataSet table)
        {
            InitializeComponent();
            dataTable = table.Tables["Tovar"];
            dataTable.Columns[0].AutoIncrement = true;
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
        }


        private void TovarTable_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "naimt";
            listBox1.ValueMember = "kt";

            listBox1.DataSource = bindingSource;
            numericUpDown1.DataBindings.Add(new Binding("Value", bindingSource, "SrG"));

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TovarEdit tovarEdit = new TovarEdit(dataTable, dataTable.Rows[bindingSource.Position], bindingSource.Position);
            tovarEdit.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TovarEdit tovarEdit = new TovarEdit(dataTable);
            tovarEdit.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int countChild = dataTable.Rows[bindingSource.Position].GetChildRows("SkladTovar").Length;
            SqlHelper.DeleteFromDataTable(ref dataTable, bindingSource.Position, countChild);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ListBox1_Format(object sender, ListControlConvertEventArgs e)
        {

        }

        private void DomainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
