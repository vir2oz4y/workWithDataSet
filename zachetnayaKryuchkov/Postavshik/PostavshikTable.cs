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
    public partial class PostavshikTable : Form
    {
        private BindingSource bindingSource;
        private DataTable dataTable;

        public PostavshikTable(DataSet table)
        {
            InitializeComponent();
            dataTable = table.Tables["Postavshiki"];
            dataTable.Columns[0].AutoIncrement = true;
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
        }

        private void PostavshikTable_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "naimP";
            listBox1.ValueMember = "KP";
            listBox1.DataSource = bindingSource;

            textBox1.DataBindings.Add("Text",bindingSource,"Telp");
        }

        private void Button1_Click(object sender, EventArgs e) //изменить
        {
            PostavshikEdit postavshikEdit = new PostavshikEdit(dataTable, dataTable.Rows[bindingSource.Position], bindingSource.Position);
            postavshikEdit.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e) //добавить
        {
            PostavshikEdit postavshikEdit = new PostavshikEdit(dataTable);
            postavshikEdit.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e) //удалить
        {
            int countChild = dataTable.Rows[bindingSource.Position].GetChildRows("SkladPost").Length;
            SqlHelper.DeleteFromDataTable(ref dataTable, bindingSource.Position, countChild);
        }
    }
}
