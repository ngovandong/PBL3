using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class MEDICINEinSTOCK_VIEW
    {
        public int idMedicine { get; set; }
        public string nameMedicine { get; set; }
        public int quantity { get; set; }
        public int import_price { get; set; }
        public int total_price { get; set; }
        public DateTime dateExpire { get; set; }
    }
}
