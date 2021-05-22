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

        public List<USER> getListUser()
        {
            List<USER> l = new List<USER>();

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

        public void addMedicine(MEDICINE m)
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                P.MEDICINEs.Add(m);
                P.SaveChanges();
            }
        }

        public List<MEDICINE> getListMedicine()
        {
            using(PharmacyModel P = new PharmacyModel())
            {
                return P.MEDICINEs.Include("UNIT").Include("MEDICINE_TYPE").ToList();
            };
        }

        public void deleteMedicine(int ID)
        {
            using(PharmacyModel P=new PharmacyModel())
            {
                MEDICINE m = P.MEDICINEs.Find(ID);
                P.MEDICINEs.Remove(m);
                P.SaveChanges();
            }
        }
        
        public void updateMedicine(MEDICINE newMedicine)
        {
            using(PharmacyModel P = new PharmacyModel())
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
    }
}
