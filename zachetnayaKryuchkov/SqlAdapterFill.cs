using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayaKryuchkov
{
    
    class SqlAdapterFill
    {
        SqlConnection connection;
        public SqlDataAdapter tovarAdapter;
        public SqlDataAdapter postavshikiAdapter;
        public SqlDataAdapter sotrudnikiAdapter;
        public SqlDataAdapter skladAdapter;

        private Dictionary<string, SqlDataAdapter> adapters = new Dictionary<string, SqlDataAdapter>();
        
        public SqlAdapterFill()
        {
            connection = new SqlConnection(Properties.Settings.Default.SKLADConnectionString);
            
        }

        public void Save(DataSet dataSet, string adapterName, string TableName)
        {
            SqlDataAdapter adapter;
            adapters.TryGetValue(adapterName, out adapter);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow r in dataSet.Tables[TableName].Rows)
            {
                if (r.RowState == DataRowState.Deleted)
                {
                    rows.Add(r);
                }
            }
            adapter.Update(rows.ToArray());
            adapter.Update(dataSet, TableName);
        }



        public DataSet Tables()
        {
            connection.Open();
            DataSet dataSet = new DataSet();

            tovarAdapter = new SqlDataAdapter(SqlRequests.AllTovar(), connection);
            tovarAdapter.Fill(dataSet, "Tovar");

            postavshikiAdapter = new SqlDataAdapter(SqlRequests.AllPostavshiki(), connection);
            postavshikiAdapter.Fill(dataSet, "Postavshiki");

            sotrudnikiAdapter = new SqlDataAdapter(SqlRequests.ALlSotrudniki(), connection);
            sotrudnikiAdapter.Fill(dataSet, "Sotrudniki");

            skladAdapter = new SqlDataAdapter(SqlRequests.Sklad(), connection);
            skladAdapter.Fill(dataSet, "Sklad");

            //relations
            dataSet.Relations.Add(new DataRelation("SkladTovar", dataSet.Tables["Tovar"].Columns["kt"], dataSet.Tables["Sklad"].Columns["kt"]));
            dataSet.Relations.Add(new DataRelation("SkladPost", dataSet.Tables["Postavshiki"].Columns["kp"], dataSet.Tables["Sklad"].Columns["kp"]));
            dataSet.Relations.Add(new DataRelation("SkladSotr", dataSet.Tables["Sotrudniki"].Columns["ks"], dataSet.Tables["Sklad"].Columns["ks"]));

            //tovar not null unique
            dataSet.Tables["Tovar"].Constraints.Add(new UniqueConstraint(dataSet.Tables["Tovar"].Columns["naimt"]));
            dataSet.Tables["Tovar"].Columns["naimt"].AllowDBNull = false;
            dataSet.Tables["Tovar"].PrimaryKey = new DataColumn[] { dataSet.Tables["Tovar"].Columns["kt"] };

            //postavshiki not null unique
            dataSet.Tables["Postavshiki"].Constraints.Add(new UniqueConstraint(dataSet.Tables["Postavshiki"].Columns["naimp"]));
            dataSet.Tables["Postavshiki"].Columns["naimp"].AllowDBNull = false;
            dataSet.Tables["Postavshiki"].PrimaryKey = new DataColumn[] { dataSet.Tables["Postavshiki"].Columns["kp"] };

            //
            DataColumn[] data = new DataColumn[3] {
                dataSet.Tables["Sklad"].Columns["datap"],
                dataSet.Tables["Sklad"].Columns["stoim"],
                dataSet.Tables["Sklad"].Columns["KT"]
            };
            dataSet.Tables["Sklad"].Constraints.Add(new UniqueConstraint(data));
            dataSet.Tables["Sklad"].Columns["datap"].AllowDBNull = false;
            dataSet.Tables["Sklad"].Columns["stoim"].AllowDBNull = false;
            dataSet.Tables["Sklad"].Columns["KT"].AllowDBNull = false;
            dataSet.Tables["Sklad"].PrimaryKey = data;
            
            //sotrudnik not null unique
            //Unique FIO

            DataColumn[] dataColumns = new DataColumn[3] {
                dataSet.Tables["Sotrudniki"].Columns["fam"],
                dataSet.Tables["Sotrudniki"].Columns["im"],
                dataSet.Tables["Sotrudniki"].Columns["otch"]
            };

            dataSet.Tables["Sotrudniki"].Constraints.Add(new UniqueConstraint(dataColumns));
            dataSet.Tables["Sotrudniki"].Columns["fam"].AllowDBNull = false;
            dataSet.Tables["Sotrudniki"].Columns["im"].AllowDBNull = false;
            dataSet.Tables["Sotrudniki"].Columns["otch"].AllowDBNull = false;
            dataSet.Tables["Sotrudniki"].PrimaryKey = new DataColumn[] { dataSet.Tables["Sotrudniki"].Columns["ks"] };

            adapters.Clear();
            adapters.Add("Tovar", tovarAdapter);
            adapters.Add("Postavshiki", postavshikiAdapter);
            adapters.Add("Sotrudniki", sotrudnikiAdapter);
            adapters.Add("Sklad", skladAdapter);

            connection.Close();
            return dataSet;
        }

        public DataSet DB()
        {
            connection.Open();
            DataSet dataSet = new DataSet();


            tovarAdapter = new SqlDataAdapter(SqlRequests.AllTovar(), connection);
            tovarAdapter.Fill(dataSet, "Tovar");

            postavshikiAdapter = new SqlDataAdapter(SqlRequests.AllPostavshiki(), connection);
            postavshikiAdapter.Fill(dataSet, "Postavshiki");

            sotrudnikiAdapter = new SqlDataAdapter(SqlRequests.ALlSotrudniki(), connection);
            sotrudnikiAdapter.Fill(dataSet, "Sotrudniki");

            SqlDataAdapter bd1 = new SqlDataAdapter(SqlRequests.BD1(), connection);
            bd1.Fill(dataSet, "BD1");
            
            SqlDataAdapter bd2 = new SqlDataAdapter(SqlRequests.BD2(), connection);
            bd2.Fill(dataSet, "BD2");
           
            SqlDataAdapter bd3 = new SqlDataAdapter(SqlRequests.BD3(), connection);
            bd3.Fill(dataSet, "BD3");

            SqlDataAdapter bd4 = new SqlDataAdapter(SqlRequests.BD4(), connection);
            bd4.Fill(dataSet, "BD4");

            SqlDataAdapter bd5 = new SqlDataAdapter(SqlRequests.BD5(), connection);
            bd5.Fill(dataSet, "BD5");
            
            SqlDataAdapter bd6 = new SqlDataAdapter(SqlRequests.BD6(), connection);
            bd6.Fill(dataSet, "BD6");
            
            SqlDataAdapter bd7 = new SqlDataAdapter(SqlRequests.BD7(), connection);
            bd7.Fill(dataSet, "BD7");

            SqlDataAdapter bd8 = new SqlDataAdapter(SqlRequests.BD8(), connection);
            bd8.Fill(dataSet, "BD8");

            dataSet.Relations.Add(new DataRelation("postTovar", dataSet.Tables["Tovar"].Columns["NaimT"], dataSet.Tables["BD1"].Columns["NaimT"]));
            dataSet.Relations.Add(new DataRelation("tovarSotr", dataSet.Tables["Tovar"].Columns["NaimT"], dataSet.Tables["BD2"].Columns["NaimT"]));
            dataSet.Relations.Add(new DataRelation("sotrCount", dataSet.Tables["Sotrudniki"].Columns["KS"], dataSet.Tables["BD5"].Columns["KS"]));
            dataSet.Relations.Add(new DataRelation("postSum", dataSet.Tables["Postavshiki"].Columns["NaimP"], dataSet.Tables["BD6"].Columns["NaimP"]));

            connection.Close();
            return dataSet;
        }
    }
}
