using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class _BLL
    {
        private static _BLL _Instance;
        public static _BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new _BLL();
                }
                return _Instance;
            }
        }
        public _BLL() { }

        public int checkUser(string username, string pass)
        {
            int i = 0;
            foreach (var item in _DAL.Instance.getListUser())
            {
                if (item.PASSWORD.Equals(pass) && username.Equals(item.USER_NAME))
                {
                    i = 1;
                }
            }
            return i;
        }
    }
}
