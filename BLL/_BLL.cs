using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Model_View;
using DAL;
using DAL.DTO;

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

        public USER getUserByUserName(string username)
        {
            foreach (var item in _DAL.Instance.getListUser())
            {
                if (item.USER_NAME.Equals(username))
                {
                    return item;
                }
            }
            return null;
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

        public void UpdateProfile(PHARMACY_PROFILE f)
        {
            _DAL.Instance.UpdateProfile(f);
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
                        Name = item.NAME,
                        UserName = item.USER_NAME,
                        Role = item.ROLE ? "Admin" : "Staff"
                    });
                }
            }
            return l;
        }

        public List<medicineSell> getlistMedicineSearch(string s)
        {
            List<medicineSell> l = new List<medicineSell>();
            foreach (var item in _DAL.Instance.getListMedicine())
            {
                if (item.MEDICINE_CODE.Contains(s) || item.MEDICINE_NAME.Contains(s))
                {
                    l.Add(new medicineSell
                    {
                        ID = item.ID,
                        code = item.MEDICINE_CODE,
                        name = item.MEDICINE_NAME,
                        Qty = item.QUANTITY,
                        sell_price = item.SALE_PRICE,
                        unit = item.UNIT.NAME,
                        STOCK_DETAIL = item.STOCK_DETAIL,

                    });
                }
            }
            return l;
        }

        public List<COMBOBOX_ITEM> getListCBBMedicine_Type()
        {
            List<COMBOBOX_ITEM> l = new List<COMBOBOX_ITEM>();

            foreach (MEDICINE_TYPE mt in _DAL.Instance.getListMedicine_Type())
            {
                l.Add(new COMBOBOX_ITEM
                {
                    ID = mt.ID,
                    Text = mt.TypeName,
                });
            }
            return l;
        }

        public List<COMBOBOX_ITEM> getListCBBUnit()
        {
            List<COMBOBOX_ITEM> l = new List<COMBOBOX_ITEM>();

            foreach (UNIT unit in _DAL.Instance.getListUnit())
            {
                l.Add(new COMBOBOX_ITEM
                {
                    ID = unit.ID,
                    Text = unit.NAME,
                });
            }
            return l;
        }

        public void addMedicine(MEDICINE m)
        {
            _DAL.Instance.addMedicine(m);
        }

        public List<MEDICINE_VIEW> getListMedicineView()
        {
            List<MEDICINE_VIEW> l = new List<MEDICINE_VIEW>();
            foreach (var item in _DAL.Instance.getListMedicine())
            {
                l.Add(new MEDICINE_VIEW
                {
                    ID = item.ID,
                    Name = item.MEDICINE_NAME,
                    original_Price = item.ORIGINAL_PRICE,
                    sale_Price = item.SALE_PRICE,
                });
            }
            return l;
        }

        public MEDICINE getMedicineByID(int ID)
        {
            foreach (var u in _DAL.Instance.getListMedicine())
            {
                if (u.ID == ID)
                {
                    return u;
                }
            }
            return null;
        }

        public MEDICINE_TYPE getMedicineTypeByID(int id)
        {
            foreach (var item in _DAL.Instance.getListMedicine_Type())
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void deleteMedicine(List<int> listIDOfDeletedItems)
        {
            foreach (int id in listIDOfDeletedItems)
            {
                _DAL.Instance.deleteMedicine(id);
            }
        }

        public void updateMedicine(MEDICINE md)
        {
            _DAL.Instance.updateMedicine(md);

        } 

        public PHARMACY_PROFILE getProfile()
        {
            return _DAL.Instance.getProfile();

        }
    }
}
