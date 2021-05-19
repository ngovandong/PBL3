using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class _DAL
    {
        private static _DAL _Instance;
        public static _DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new _DAL();
                }
                return _Instance;
            }
        }
        public _DAL() { }
        public List<STAFF> getListUser()
        {
            List<STAFF> l = new List<STAFF>();

            using (PharmacyModel P = new PharmacyModel())
            {
                return P.STAFFs.ToList();
            }
        }
    }
}
