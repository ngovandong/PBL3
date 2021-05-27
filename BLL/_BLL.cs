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

        public List<reportStaff> getListReportStaff()
        {
            List<reportStaff> l = new List<reportStaff>();
            foreach (var item in _DAL.Instance.getListStaff())
            {
                int s1 = 0;
                int s2 = 0;
                foreach (var i in item.INVOICEs)
                {
                    if (i.DATE.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"))
                    {
                        s1 += i.TOTAL;
                        s2++;
                    }
                }
                l.Add(new reportStaff
                {
                    StaffName = item.NAME,
                    TotalSold = s1,
                    NumberOfInvoice = s2
                });
            }
            return l;
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

        public CUSTOMER AddCustomer(CUSTOMER c)
        {
            return _DAL.Instance.getCus(c);
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

        public int getProgressValue1()
        {
            return _DAL.Instance.getListStockDetail().Where(p => p.dateExpire < DateTime.Now && p.QUANTITY > 0).Count();
        }
        public int getProgressValue2()
        {
            return  _DAL.Instance.getListStockDetail().Where(p => p.QUANTITY > 0).Count();
        }

        public int getProgressValue3()
        {
            return _DAL.Instance.getListMedicine().Where(p=>p.QUANTITY==0).Count();
        }
        public int getProgressValue4()
        {
            return _DAL.Instance.getListMedicine().Count();
        }

        public List<stockDetailView> getListStockDetailView()
        {
            List<stockDetailView> l = new List<stockDetailView>();
            foreach (STOCK_DETAIL item in _DAL.Instance.getListStockDetail())
            {
                l.Add(new stockDetailView
                {
                    StockName = item.STOCK.Name,
                    MedicineName = item.MEDICINE.MEDICINE_NAME,
                    Available = item.QUANTITY,
                    EXP = item.dateExpire.ToShortDateString()
                }) ;
            }
            return l;
        }

        public void UpdateUser(USER u)
        {
            _DAL.Instance.UpdateUser(u);
        }

        public List<CUSTOMER> getListCus(string s)
        {
            List<CUSTOMER> l = new List<CUSTOMER>();
            foreach (CUSTOMER item in _DAL.Instance.getListCus())
            {
                if (item.Customer_name.Contains(s) || item.Phone.Contains(s))
                {
                    l.Add(item);
                }
            }
            return l;
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
                        location = item.LOCATION,
                        Barcode = item.BARCODE,
                        Ingredient = item.INGREDIENT,
                        type = item.MEDICINE_TYPE.TypeName,
                        quantysell=1
                    }) ;
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

        public List<SAMPLE_VIEW> getListSampleView(string text)
        {
            return _DAL.Instance.getListSample().Where(p=>p.NAME.Contains(text)).Select(p=> new SAMPLE_VIEW { 
                ID=p.SAMPLEID,
                Name=p.NAME
            }).ToList();

        }

        public SAMPLE getSample(int ID)
        {
            return _DAL.Instance.getListSample().Where(p => p.SAMPLEID == ID).Select(p => p).Single();
        }

        public void UpdateStockDetail(STOCK_DETAIL stock_detail, int quantysell)
        {
            stock_detail.QUANTITY -= quantysell;
            _DAL.Instance.UpdateStockDetail(stock_detail);
            _DAL.Instance.UpdateMedicine(stock_detail.ID_MEDICINE, quantysell);
        }

        public List<medicineSell> getlistMedicineSearch(int  ID)
        {
            SAMPLE a = _DAL.Instance.getListSample().Where(p => p.SAMPLEID == ID).Select(p => p).Single();
            List<medicineSell> l = new List<medicineSell>();

            foreach (var item in a.SAMPLE_DETAIL)
            {
                l.Add(new medicineSell
                {
                    ID = item.MEDICINE.ID,
                    code = item.MEDICINE.MEDICINE_CODE,
                    name = item.MEDICINE.MEDICINE_NAME,
                    Qty = item.MEDICINE.QUANTITY,
                    sell_price = item.MEDICINE.SALE_PRICE,
                    unit = item.MEDICINE.UNIT.NAME,
                    STOCK_DETAIL = item.MEDICINE.STOCK_DETAIL,
                    quantysell=item.QTY,
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

        public List<medicineSell> getlistMedicineSearch2(int id)
        {
            INVOICE I=_DAL.Instance.getListInvoice().Where(p=>p.ID_INVOICE==id).Select(p=>p).Single();
            List<medicineSell> l = new List<medicineSell>();

            foreach (var item in I.INVOICE_DETAIL)
            {
                l.Add(new medicineSell
                {
                    ID = item.MEDICINE.ID,
                    code = item.MEDICINE.MEDICINE_CODE,
                    name = item.MEDICINE.MEDICINE_NAME,
                    Qty = item.MEDICINE.QUANTITY,
                    sell_price = item.MEDICINE.SALE_PRICE,
                    unit = item.MEDICINE.UNIT.NAME,
                    STOCK_DETAIL = item.MEDICINE.STOCK_DETAIL,
                    quantysell = item.QUANTITY,
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

        public void AddInvoice(INVOICE i)
        {
            _DAL.Instance.AddInvoice(i);
        }

        public void updateMedicine(MEDICINE md)
        {
            _DAL.Instance.updateMedicine(md);

        } 

        public PHARMACY_PROFILE getProfile()
        {
            return _DAL.Instance.getProfile();

        }
        public STOCK_VIEW stockToStockView(STOCK temp)
        {
            return new STOCK_VIEW()
            {
                id = temp.ID,
                nameStock = temp.Name,
                nameSupplier = temp.SUPPLIER.NAME,
                dateImport = temp.DATE.Value.Date,
                priceTotal = temp.PRICETOTAL
            };
        }
        public List<STOCK_VIEW> getListStockView(string name, string option)
        {
            List<STOCK_VIEW> results = new List<STOCK_VIEW>();
            if ("NAME" == option)
            {
                foreach(var item in _DAL.Instance.getListStock().Where(p => p.Name.ToLower().Contains(name.ToLower())))
                {
                    results.Add(stockToStockView(item));
                }
            }
            else if ("SUPPLIER" == option)
            {
                foreach(var item in _DAL.Instance.getListStock().Where(p => p.SUPPLIER.NAME.ToLower().Contains(name.ToLower())))
                {
                    results.Add(stockToStockView(item));
                }
            }
            else
            {
                
            }
            return results;
        }

        public List<chart> getListChart0()
        {
            List<chart> l=_DAL.Instance.getListInvoiceDetail().GroupBy(p => p.INVOICE.DATE.Date.ToShortDateString()).Select(c=>new chart { date=c.Key,originalPrice=c.Sum(p=>p.ORIGINAL_PRICE),sellPrice=c.Sum(p=>p.SALE_PRICE)}).OrderByDescending(p=>p.date).Take(7).Reverse().ToList();

            return l;
        }
        public List<chart> getListChart1()
        {
            List<chart> l = _DAL.Instance.getListInvoiceDetail().GroupBy(p => p.INVOICE.DATE.ToString("MM/yyyy")).Select(c => new chart { date = c.Key, originalPrice = c.Sum(p => p.ORIGINAL_PRICE), sellPrice = c.Sum(p => p.SALE_PRICE) }).OrderByDescending(p => p.date).Take(7).Reverse().ToList();

            return l;
        }

        public void addSample(SAMPLE sample)
        {
            _DAL.Instance.addSample(sample);
        }
    }
}
