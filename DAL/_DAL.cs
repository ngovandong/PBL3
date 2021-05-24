using System;
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
                return P.USERs.ToList();
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

        public void DelUser(int i)
        {
            using(PharmacyModel P= new PharmacyModel())
            {
                USER u = P.USERs.Find(i);
                P.USERs.Remove(u);
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

        public List<MEDICINE> getListMedicine()
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.MEDICINEs.Include("UNIT").Include("STOCK_DETAIL.STOCK").ToList();
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
                return P.STOCKs.ToList();
            }
        }
        public List<MEDICINE> getMedicine(int id)
        {
            using (PharmacyModel P = new PharmacyModel())
            {
                return P.MEDICINEs.Where(p => id == p.ID).ToList();
            }
        }
    }
}
