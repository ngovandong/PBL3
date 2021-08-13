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

        public List<INVOICE_VIEW_REPORT> getListInvoice(int id, string nameCustomer, string nameMedicine)
        {
            List<INVOICE> ds = _DAL.Instance.getListInvoiceIncludeCustomer().Where(p => p.User_ID == id).ToList();
            List<INVOICE> listInvoice = new List<INVOICE>();
            if ("" == nameCustomer) listInvoice = ds;
            else
            {
                foreach(var invoice in ds)
                {
                    if(invoice.CUSTOMER != null && invoice.CUSTOMER.Customer_name.ToLower().Contains(nameCustomer.ToLower()))
                    {
                        listInvoice.Add(invoice);
                    }
                }
            }
            List<INVOICE> results = new List<INVOICE>();
            foreach(var invoice in listInvoice)
            {
                foreach(var invoiceDetail in invoice.INVOICE_DETAIL)
                {
                    if(invoiceDetail.MEDICINE.MEDICINE_NAME.ToLower().Contains(nameMedicine.ToLower()))
                    {
                        results.Add(invoice);
                        break;
                    }
                }
            }
            return results.Select(p => new INVOICE_VIEW_REPORT
            {
                Id = p.ID_INVOICE,
                Date = p.DATE,
                Charge = p.CHARGE,
                Discount = p.DISCOUNT,
                CustomerName = p.CUSTOMER == null ? "" : p.CUSTOMER.Customer_name
            }).Reverse().ToList();
        }
        public INVOICE getINVOICE(int id)
        {
            return _DAL.Instance.getListInvoiceIncludeCustomer().Where(p => p.ID_INVOICE == id).ToList()[0];
        }
        public List<INVOICE_DETAIL_VIEW> getListInvoice_Detail(int id)
        {
            List<INVOICE_DETAIL> listInvoice_detail = _DAL.Instance.getListInvoiceDetail().Where(p => p.ID_INVOICE == id).ToList();
            List<INVOICE_DETAIL_VIEW> results = new List<INVOICE_DETAIL_VIEW>();
            foreach(var invoice_detail in listInvoice_detail)
            {
                results.Add(new INVOICE_DETAIL_VIEW()
                {
                    nameMedicine = invoice_detail.MEDICINE.MEDICINE_NAME,
                    quantity = invoice_detail.QUANTITY,
                    total = invoice_detail.SALE_PRICE,
                });
            }
            return results;
        }
        public void DeleteMedicineExpired()
        {
            foreach (var item in _DAL.Instance.getListStockDetail())
            {
                if (item.dateExpire < DateTime.Now)
                {
                    _DAL.Instance.DeleteStockDetail(item);
                }
            }
        }

        public void CheckExpiredMedicine()
        {
            foreach (var item in _DAL.Instance.getListStockDetail())
            {
                if (item.dateExpire < DateTime.Now)
                {
                    _BLL.Instance.UpdateStockDetail(item, item.QUANTITY);
                }
            }
        }

        public List<staffChart> getListChartStaffDate(int id)
        {
            USER u= _DAL.Instance.getListStaff().Where(p => p.ID == id).Single();

            return u.INVOICEs.GroupBy(p => p.DATE.ToShortDateString()).Select(c => new staffChart { date = c.Key, sale = c.Sum(p => p.CHARGE),qty=c.Count() }).OrderByDescending(p=>p.date).Take(7).Reverse().ToList();
        }

        public List<staffChart> getListChartStaffMonth(int id)
        {
            USER u = _DAL.Instance.getListStaff().Where(p => p.ID == id).Single();

            return u.INVOICEs.GroupBy(p => p.DATE.ToString("MM/yyyy")).Select(c => new staffChart { date = c.Key, sale = c.Sum(p => p.CHARGE), qty = c.Count() }).OrderByDescending(p => p.date).Take(7).Reverse().ToList();
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

        public reportStaff getReportStaff(int id, bool b)
        {
            USER u = _DAL.Instance.getListStaff().Where(p => p.ID == id).Single();
            int s1 = 0;
            int s2 = 0;
            if (b)
            {
                foreach (var i in u.INVOICEs)
                {
                    if (i.DATE.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        s1 += i.TOTAL;
                        s2++;
                    }
                }
            }
            else
            {
                foreach (var i in u.INVOICEs)
                {
                    if (i.DATE.ToString("MM/yyyy") == DateTime.Now.ToString("MM/yyyy"))
                    {
                        s1 += i.TOTAL;
                        s2++;
                    }
                }
            }
            return (new reportStaff
            {
                StaffName = u.NAME,
                TotalSold = s1,
                NumberOfInvoice = s2
            });
        }

        public List<LISTMEDICINE> getListSuggest(string s)
        {
            s = s.ToLower();
            List<LISTMEDICINE> l = new List<LISTMEDICINE>();
            foreach (var item in _DAL.Instance.getListSuggest())
            {
                if (item.medicine_name.ToLower().Contains(s))
                {
                    l.Add(item);
                }
            }
            return l;
        }

        public int checkUser(string username, string pass)
        {
            int i = 0;
            var user = _DAL.Instance.getListUser().Where(p => p.USER_NAME == username).FirstOrDefault();
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(pass, user.PASSWORD))
                {
                    if (user.ROLE)
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

        public bool checkBarcode(string s)
        {
            s.ToLower();
            return _DAL.Instance.getListMedicine().Where(p => p.BARCODE.ToLower() == s).Count() == 0;
        }

        public bool checkNameMedicine(string s)
        {
            s.ToLower();
            return _DAL.Instance.getListMedicine().Where(p => p.MEDICINE_CODE.ToLower() == s).Count() == 0;
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
            return _DAL.Instance.getListStockDetail().Where(p => p.dateExpire < DateTime.Now).Count();
        }

        public int getProgressValue2()
        {
            return _DAL.Instance.getListStockDetail().Count();
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
                    idStock = item.ID_STOCK,
                    idMedicine = item.ID_MEDICINE,
                    StockName = item.STOCK.Name,
                    MedicineName = item.MEDICINE.MEDICINE_NAME,
                    Available = item.QUANTITY,
                    EXP = item.dateExpire.ToShortDateString(),
                    Expired = item.dateExpire < DateTime.Now
                }) ;
            }
            return l;
        }

        public void UpdateUser(USER u)
        {
            int costParameter = 12;
            u.PASSWORD = BCrypt.Net.BCrypt.HashPassword(u.PASSWORD,costParameter);
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
            int costParameter = 12;
            u.PASSWORD = BCrypt.Net.BCrypt.HashPassword(u.PASSWORD,costParameter);
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
                if (item.NAME.ToLower().Contains(s.ToLower()) || item.USER_NAME.ToLower().Contains(s.ToLower()))
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
                if (item.MEDICINE_CODE.Contains(s) || item.MEDICINE_NAME.ToLower().Contains(s.ToLower()))
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
                        import_price = item.ORIGINAL_PRICE,
                        unit = item.UNIT.NAME,
                        quantityInStock = 1,
                        quantityInKho = item.QUANTITY,
                        sale_price = item.SALE_PRICE,
                        HSD = DateTime.Now.Date
                    });
                }
            }
            return ls;
        }

        public void addMedicineQuantity(MedicineStock medicine)
        {
            _DAL.Instance.UpdateMedicine(medicine.ID, medicine.quantityInStock);
        }
        public void subMedicineQuantity(STOCK_DETAIL stDetail)
        {
            _DAL.Instance.UpdateMedicine(stDetail.ID_MEDICINE, -stDetail.QUANTITY);
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
            return _DAL.Instance.getListSample().Where(p => p.NAME.ToLower().Contains(text.ToLower())).Select(p=> new SAMPLE_VIEW { 
                ID=p.SAMPLEID,
                Name=p.NAME
            }).ToList();

        }

        public SAMPLE getSampleByID(int ID)
        {
            return _DAL.Instance.getListSample().Find(obj => obj.SAMPLEID == ID);
        }

        public void UpdateStockDetail(STOCK_DETAIL stock_detail, int quantysell)
        {
            stock_detail.QUANTITY -= quantysell;
            _DAL.Instance.UpdateStockDetailQuantity(stock_detail);
            _DAL.Instance.UpdateMedicine(stock_detail.ID_MEDICINE, -quantysell);
        }

        public List<medicineSell> getListMedicineBySampleID(int ID)
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
            m.DELETED = false;
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
                    Quantity=item.QUANTITY
                });
            }
            return l;
        }

        public List<medicineView> getListMedicineViewReport()
        {
            return _DAL.Instance.getListMedicine().Where(p => p.QUANTITY == 0).Select(p => new medicineView { ID = p.MEDICINE_CODE, Name = p.MEDICINE_NAME }).ToList();
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
        public List<STOCK_VIEW> getListStockView(string name, string option, DateTime begin, DateTime finish)
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
                List<STOCK> listStock = _DAL.Instance.getListStock();
                foreach(STOCK stock in listStock)
                {
                    foreach(STOCK_DETAIL stockDetail in stock.STOCK_DETAIL)
                    {
                        if (stockDetail.MEDICINE.MEDICINE_NAME.ToLower().Contains(name.ToLower()))
                        {
                            results.Add(stockToStockView(stock));
                            break;
                        }
                    }
                }
            }
            List<STOCK_VIEW> final_results = new List<STOCK_VIEW>();
            final_results.AddRange(results);

            foreach (STOCK_VIEW stock_view in results)
            {
                if (DateTime.Compare(stock_view.dateImport, begin) < 0 || DateTime.Compare(stock_view.dateImport, finish) > 0)
                {
                    final_results.Remove(stock_view);
                }
            }
            return final_results;
        }
        public STOCK getStock(int id)
        {
            return _DAL.Instance.getListStock().Where(o => o.ID == id).ToList()[0];
        }
        public List<MEDICINEinSTOCK_VIEW> getListMEDICINEinStockView(int id)
        {
            List<MEDICINEinSTOCK_VIEW> results = new List<MEDICINEinSTOCK_VIEW>();
            foreach(var item in getStock(id).STOCK_DETAIL)
            {
                results.Add(new MEDICINEinSTOCK_VIEW
                {
                    idMedicine = item.ID_MEDICINE,
                    nameMedicine = item.MEDICINE.MEDICINE_NAME,
                    quantity = item.QUANTITY,
                    import_price = item.ORGIGINAL_PRICE,
                    total_price = item.ORGIGINAL_PRICE * item.QUANTITY,
                    dateExpire = item.dateExpire.Date
                });

            }
            return results;
        }
        public List<MedicineStock> STOCKtoMedicineStock(STOCK stock)
        {
            List<MedicineStock> results = new List<MedicineStock>();
            foreach (var item in stock.STOCK_DETAIL)
            {
                results.Add(new MedicineStock
                {
                    ID = item.ID_MEDICINE,
                    name = item.MEDICINE.MEDICINE_NAME,
                    unit = item.MEDICINE.UNIT.NAME,
                    original_price = item.MEDICINE.ORIGINAL_PRICE,
                    import_price = item.ORGIGINAL_PRICE,
                    final_price = item.ORGIGINAL_PRICE * item.QUANTITY,
                    sale_price = 0,
                    quantityInStock = item.QUANTITY,
                    HSD = item.dateExpire.Date,
                    ID_STOCK = item.ID_STOCK
                });
            }
            return results;
        }

        public List<Chart> getListChart0()
        {
            List<Chart> l=_DAL.Instance.getListInvoiceDetail().GroupBy(p => p.INVOICE.DATE.Date.ToShortDateString()).Select(c=>new Chart { date=c.Key,originalPrice=c.Sum(p=>p.ORIGINAL_PRICE),sellPrice=c.Sum(p=>p.SALE_PRICE)}).OrderByDescending(p=>p.date).Take(7).Reverse().ToList();

            return l;
        }
        public List<Chart> getListChart1()
        {
            List<Chart> l = _DAL.Instance.getListInvoiceDetail().GroupBy(p => p.INVOICE.DATE.ToString("MM/yyyy")).Select(c => new Chart { date = c.Key, originalPrice = c.Sum(p => p.ORIGINAL_PRICE), sellPrice = c.Sum(p => p.SALE_PRICE) }).OrderByDescending(p => p.date).Take(7).Reverse().ToList();

            return l;
        }

        public void addSample(SAMPLE sample)
        {
            _DAL.Instance.addSample(sample);
        }

        public void updateSample(SAMPLE newSample)
        {
            _DAL.Instance.updateSample(newSample);
        }

        public void deleteSample(List<int> listIdOfDeletedItems)
        {
            _DAL.Instance.deleteSample(listIdOfDeletedItems);
        }

        public void addMedicineUnit(string name)
        {
            _DAL.Instance.addMedicineUnit(name);
        }

        public void addMedicineType(string name)
        {

            _DAL.Instance.addMedicineType(name);
        }
    
        public void UpdateStock(STOCK stock)
        {
           _DAL.Instance.UpdateStock(stock);
        }
        
        public void DeleteStockDetail(STOCK_DETAIL stDetail)
        {
            _DAL.Instance.DeleteStockDetail(stDetail);
        }
        public void AddStockDetail(STOCK_DETAIL stDetail)
        {
            _DAL.Instance.AddStockDetail(stDetail);
        }
        public void DeleteStock(int id)
        {
            _DAL.Instance.DeleteStock(id);
        }

    }
}
