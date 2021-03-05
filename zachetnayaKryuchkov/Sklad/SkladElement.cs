using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayaKryuchkov.Sklad
{
    class SkladElement
    {
        public string date { get; set; }
        public string obiem { get; set; }
        public string stoim { get; set; }

        public SkladElement(DataGridViewRow row)
        {
            date = row.Cells[0].Value.ToString();
            obiem = row.Cells[1].Value.ToString();
            stoim = row.Cells[2].Value.ToString();
        }
    }
}
