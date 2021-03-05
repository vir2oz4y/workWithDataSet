using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov
{
    static class SqlHelper
    {
        public static void UpdateDataTable(ref DataTable dataTable, int index, params string[] elements)
        {
            var newRow = dataTable.Rows[index].ItemArray;
            for (int i = 0; i < elements.Length; i++)
            {
                newRow[i+1] = elements[i];
            }
            dataTable.Rows[index].ItemArray = newRow;
        }

        public static void InsertIntoDataTable(string PrKey, ref DataTable dataTable, params object[] elements)
        {
            try
            {
                int Pk = dataTable.Rows[dataTable.Rows.Count - 1].Field<int>(PrKey) + 1;
                var newRow = dataTable.NewRow().ItemArray;
                newRow[0] = Pk;
                for (int i = 0; i < elements.Length; i++)
                {
                    newRow[i + 1] = elements[i];
                }
                try
                {
                    dataTable.Rows.Add(newRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        public static void InsertIntoDataTable(ref DataTable dataTable, params object[] elements)
        {

            var newRow = dataTable.NewRow().ItemArray;

            for (int i = 0; i < elements.Length; i++)
            {
                newRow[i] = elements[i];
            }
            try
            {
                dataTable.Rows.Add(newRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void DeleteFromDataTable(ref DataTable dataTable, int index, int countChild)
        {
            if (countChild > 0)
            {
                MessageBox.Show("Невозможно удалить.\nИмеются зависимые строки в поставках.");
            }
            else
            {
                if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataTable.Rows[index].Delete();
                }
            }
        }

        public static void DeleteFromDataTable(ref DataTable dataTable, int index)
        {
            if (MessageBox.Show("Удалить ?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataTable.Rows[index].Delete();
            }
        }

        public static DialogResult SaveToDataBase(DataSet dataSet, SqlAdapterFill sql)
        {
            DataSet newSet = dataSet.GetChanges();

            if (newSet != null)
            {
                DialogResult resultUpdate = MessageBox.Show(
                   "Сохранить изменения в базу данных?",
                   "ВНИМАНИЕ!!!",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1
               );
                if (resultUpdate == DialogResult.Yes)
                {
                    sql.Save(dataSet, "Tovar","Tovar");
                    sql.Save(dataSet, "Postavshiki", "Postavshiki");
                    sql.Save(dataSet, "Sotrudniki", "Sotrudniki");
                    sql.Save(dataSet, "Sklad", "Sklad");

                }
            }

            DialogResult result = MessageBox.Show(
                    "Продолжить работу в приложении?",
                    "ВНИМАНИЕ!!!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1
                );

            return result;
        }

    }
}
