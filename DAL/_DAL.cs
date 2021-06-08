﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.DTO;

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

        public List<USER> getListUser()
        {

            using (PharmacyModel P = new PharmacyModel())
            {
                return P.USERs.Where(e=>e.DELETED==false).Include("INVOICEs.CUSTOMER").ToList();
            }
        }

        public void AddUser(USER u)
        {
            using(PharmacyModel p= new PharmacyModel())
            {
                p.USERs.Add(u);
                p.SaveChanges();
            }
        }

        public List<USER> getListStaff()
        {
            using (PharmacyModel p = new PharmacyModel())
            {
                return p.USERs.Include("INVOICEs").Where(e => e.ROLE == false).ToList();
            }
        }

        public void DelUser(int i)
        {
            using(PharmacyModel P= new PharmacyModel())
            {
                USER u = P.USERs.Find(i);
                u.DELETED = true;
                P.SaveChanges();
            }
        }

        public void UpdateUser(USER u)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                USER uNew = P.USERs.Find(u.ID);
                uNew.NAME = u.NAME;
                uNew.PASSWORD = u.PASSWORD;
                uNew.PHONE = u.PHONE;
                uNew.ADDRESS = u.ADDRESS;
                uNew.DateOfBirth = u.DateOfBirth;
                P.SaveChanges();
            }
        }

        public CUSTOMER getCus(CUSTOMER c)
        {
            using(PharmacyModel P= new PharmacyModel())
            {
                P.CUSTOMERs.Add(c);
                P.SaveChanges();
                return P.CUSTOMERs.OrderByDescending(f => f.ID).FirstOrDefault();
            }
        }

        public List<STOCK_DETAIL> getListStockDetail()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.STOCK_DETAIL.Include("STOCK").Include("MEDICINE").ToList();
            }
        }

        public List<MEDICINE_TYPE> getListMedicine_Type()
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                return P.MEDICINE_TYPE.ToList();
            }
        }

        public List<UNIT> getListUnit()
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                return P.UNITs.ToList();
            }
        }

        public List<CUSTOMER> getListCus()
        {
            using (PharmacyModel P=new PharmacyModel())
            {
                return P.CUSTOMERs.Include("INVOICEs").ToList();
            }
        }

        public void addMedicine(MEDICINE m)
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                P.MEDICINEs.Add(m);
                P.SaveChanges();
            }
        }



        public void deleteMedicine(int ID)
        {
            using(PharmacyModel P=new PharmacyModel())
            {
                MEDICINE m = P.MEDICINEs.Find(ID);
                m.DELETED = true;
                m.QUANTITY = 0;
                P.SaveChanges();
            }
        }

        public void updateMedicine(MEDICINE newMedicine)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                MEDICINE oldMedicine = P.MEDICINEs.Find(newMedicine.ID);
                oldMedicine.MEDICINE_CODE = newMedicine.MEDICINE_CODE;
                oldMedicine.MEDICINE_NAME = newMedicine.MEDICINE_NAME;
                oldMedicine.TYPEID = newMedicine.TYPEID;
                oldMedicine.BARCODE = newMedicine.BARCODE;
                oldMedicine.BRAND = newMedicine.BRAND;
                oldMedicine.ID_SUB = newMedicine.ID_SUB;
                oldMedicine.LOCATION = newMedicine.LOCATION;
                oldMedicine.INGREDIENT = newMedicine.INGREDIENT;
                oldMedicine.CONTENT = newMedicine.CONTENT;
                oldMedicine.UNIT_ID = newMedicine.UNIT_ID;
                oldMedicine.QUANTITY = newMedicine.QUANTITY;
                oldMedicine.ORIGINAL_PRICE = newMedicine.ORIGINAL_PRICE;
                oldMedicine.SALE_PRICE = newMedicine.SALE_PRICE;
                P.SaveChanges();
            }
        }

        public List<LISTMEDICINE> getListSuggest()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.LISTMEDICINEs.ToList();
            }
        }

        public List<MEDICINE> getListMedicine()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.MEDICINEs.Include("UNIT").Include("STOCK_DETAIL.STOCK").Include("MEDICINE_TYPE").Where(p=>p.DELETED==false).ToList();
            }
        }

        public PHARMACY_PROFILE getProfile()
        {
            using(PharmacyModel P= new PharmacyModel())
            {
                return P.PHARMARCY_PROFILEs.OrderByDescending(f => f.PHARMACY_PROFILEID).FirstOrDefault();
            }
        }
        public void addSupplier(SUPPLIER s)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                P.SUPPLIERs.Add(s);
                P.SaveChanges();
            }
        }
        public List<SUPPLIER> getListSupplier()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.SUPPLIERs.ToList();
            }
        }
        public void addStock(STOCK stock)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                P.STOCKs.Add(stock);
                P.SaveChanges();
            }
        }
        public List<STOCK> getListStock()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.STOCKs.Include("SUPPLIER").Include("STOCK_DETAIL.MEDICINE.MEDICINE_TYPE").Include("STOCK_DETAIL.MEDICINE.UNIT").ToList();
            }
        }
        public List<MEDICINE> getMedicine(int id)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.MEDICINEs.Where(p => id == p.ID).ToList();
            }
        }

        public void UpdateProfile(PHARMACY_PROFILE f)
        {
            using(PharmacyModel P=new PharmacyModel())
            {
                P.PHARMARCY_PROFILEs.Add(f);

                P.SaveChanges();
            }
        }

        public void AddInvoice(INVOICE i)
        {
            using(PharmacyModel P=new PharmacyModel())
            {
                P.INVOICEs.Add(i);
                P.SaveChanges();
            }
        }

        

        public void UpdateStock(STOCK stock)
        {
            using(PharmacyModel p = new PharmacyModel())
            {
                STOCK sNew = p.STOCKs.Find(stock.ID);
                sNew.Name = stock.Name;
                sNew.DATE = stock.DATE.Value.Date;
                sNew.NOTE = stock.NOTE;
                sNew.PRICETOTAL = stock.PRICETOTAL;
                sNew.supplierId = stock.supplierId;
                p.SaveChanges();
            }
        }
        
        public void AddStockDetail(STOCK_DETAIL stDetail)
        {
            using (PharmacyModel p = new PharmacyModel())
            {
                p.STOCK_DETAIL.Add(stDetail);
                p.SaveChanges();

            }
        }
        public void DeleteStockDetail(STOCK_DETAIL stDetail)
        {
            using(PharmacyModel p = new PharmacyModel())
            {
                STOCK_DETAIL stNew = p.STOCK_DETAIL.Find(stDetail.ID_MEDICINE, stDetail.ID_STOCK);
                p.STOCK_DETAIL.Remove(stNew);
                p.SaveChanges();
            }
        }
        public void DeleteStock(int idStock)
        {
            using (PharmacyModel p = new PharmacyModel())
            {
                STOCK newStock = p.STOCKs.Find(idStock);
                p.STOCKs.Remove(newStock);
                p.SaveChanges();
            }
        }

        public List<SAMPLE> getListSample()
        {
            using(PharmacyModel P= new PharmacyModel())
            {
                return P.SAMPLEs.Include("SAMPLE_DETAIL.MEDICINE.STOCK_DETAIL.STOCK").Include("SAMPLE_DETAIL.MEDICINE.UNIT").ToList();
            }
        }

        public List<INVOICE> getListInvoice()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.INVOICEs.Include("INVOICE_DETAIL.MEDICINE.UNIT").Include("INVOICE_DETAIL.MEDICINE.STOCK_DETAIL.STOCK").ToList();
            }
        }

        public void UpdateStockDetailQuantity(STOCK_DETAIL stock_detail)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                STOCK_DETAIL s= P.STOCK_DETAIL.Find(stock_detail.ID_MEDICINE, stock_detail.ID_STOCK);
                s.QUANTITY = stock_detail.QUANTITY;
                P.SaveChanges();
            }
        }

        public void UpdateMedicine(int iD_MEDICINE, int quantysell)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                MEDICINE m=P.MEDICINEs.Find(iD_MEDICINE);
                m.QUANTITY += quantysell;
                P.SaveChanges();
            }
        }

        public List<INVOICE_DETAIL> getListInvoiceDetail()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.INVOICE_DETAIL.Include("INVOICE").ToList();
            }
        }
        
        public void addSample(SAMPLE sample)
        {
            using(PharmacyModel P =new PharmacyModel())
            {
                P.SAMPLEs.Add(sample);
                P.SaveChanges();
            }
        }

        public void addMedicineUnit(string name)
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                P.UNITs.Add(new UNIT
                {
                    NAME = name,
                });
                P.SaveChanges();
            }
        }

        public void addMedicineType(string name)
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                P.MEDICINE_TYPE.Add(new MEDICINE_TYPE
                {
                    TypeName = name,
                });
                P.SaveChanges();
            }
        }
    }
}
