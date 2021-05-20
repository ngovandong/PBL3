using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Model_View;
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

        public USER getUser(int ID)
        {
            foreach (var item in _DAL.Instance.getListUser())
            {
                if (item.ID == ID)
                    return item;
            }
            return null;
        }

        public int checkUser(string username, string pass)
        {
            int i = 0;
            foreach (var item in _DAL.Instance.getListUser())
            {
                if (item.PASSWORD.Equals(pass) && username.Equals(item.USER_NAME))
                {
                    if (item.ROLE)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 2;
                    }
                }
            }
            return i;
        }

        public void UpdateUser(USER u)
        {
            _DAL.Instance.UpdateUser(u);
        }

        public List<USER_VIEW> getListUser()
        {
            List<USER_VIEW> l = new List<USER_VIEW>();
            foreach (var u in _DAL.Instance.getListUser())
            {
                l.Add(new USER_VIEW
                {
                    ID = u.ID,
                    Name = u.NAME,
                    Role = u.ROLE ? "Admin" : "Staff",
                    UserName = u.USER_NAME
                });
            }
            return l;
        }

        public void DelUser(List<int> lint)
        {
            foreach (var i in lint)
            {
                if (i == 1)
                    break;
                _DAL.Instance.DelUser(i);
            }
        }

        public void AddUser(USER u)
        {
            _DAL.Instance.AddUser(u);
        }

        public bool checkUserHasAlready(string username)
        {
            foreach (var u in _DAL.Instance.getListUser())
            {
                if (u.USER_NAME.Equals(username))
                {
                    return false;
                }
            }
            return true;
        }

        public List<USER_VIEW> SearchUser(string s)
        {
            List<USER_VIEW> l = new List<USER_VIEW>();
            foreach (var item in _DAL.Instance.getListUser())
            {
                if (item.NAME.Contains(s) || item.USER_NAME.Contains(s))
                {
                    l.Add(new USER_VIEW
                    {
                        ID = item.ID,
                        Name=item.NAME,
                        UserName=item.USER_NAME,
                        Role=item.ROLE?"Admin":"Staff"
                    });

                }
            }
            return l;
        }
    }
}
