using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class stockDetailView
    {
        public int idStock { get; set; }
        public int idMedicine { get; set; }
        public string StockName { get; set; }
        public string MedicineName { get; set; }
        public int Available { get; set; }
        public string EXP { get; set; }
        public bool Expired { get; set; }
    }
}
