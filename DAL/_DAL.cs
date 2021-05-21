﻿using System;
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
    }
}
