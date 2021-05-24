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
        private _BLL() { }

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
                        STOCK_DETAIL=item.STOCK_DETAIL,
                        
                    });
                }
            }
            return l;
        }
        public List<MedicineStock> getlistMedicineSearchinStock(string s)
        {
            List<MedicineStock> ls = new List<MedicineStock>();
            foreach (var item in _DAL.Instance.getListMedicine())
            {
                if (item.MEDICINE_CODE.Contains(s) || item.MEDICINE_NAME.Contains(s))
                {
                    ls.Add(new MedicineStock
                    {
                        ID = item.ID,
                        name = item.MEDICINE_NAME,
                        original_price = item.ORIGINAL_PRICE,
                        unit = item.UNIT.NAME,
                        quantityInKho = item.QUANTITY,
                        sale_price = item.SALE_PRICE
                    });
                }
            }
            return ls;
        }
        public void addSupplier(SUPPLIER m)
        {
            _DAL.Instance.addSupplier(m);
        }
        public List<SupplierView> getListSupplierView(string name)
        {
            return _DAL.Instance.getListSupplier().Where(p => p.NAME.ToLower().Contains(name.ToLower())).Select(p => new SupplierView() { ID = p.ID, Name = p.NAME, Phone = p.PHONE_NUMBER }).ToList();
        }
        public bool checkSupplier(int id)
        {
            foreach (var item in _DAL.Instance.getListSupplier())
            {
                if (id == item.ID)
                    return true;
            }
            return false;
        }
        public bool checkSupplier(string name)
        {
            foreach (var item in _DAL.Instance.getListSupplier())
            {
                if (name == item.NAME)
                    return true;
            }
            return false;
        }
        public SUPPLIER getSupplier(int id)
        {
            foreach (var item in _DAL.Instance.getListSupplier())
            {
                if (id == item.ID)
                {
                    return item;
                }
            }
            return null;
        }
        public void addStock(STOCK stock)
        {
            _DAL.Instance.addStock(stock);
        }
        public MEDICINE getMedicineStocktoMedicine(MedicineStock m)
        {
            return _DAL.Instance.getMedicine(m.ID)[0];
        }
        public bool checkNameStock(string name)
        {
            foreach (var item in _DAL.Instance.getListStock())
            {
                if (name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
