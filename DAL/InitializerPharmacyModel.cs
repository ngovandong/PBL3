using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.DTO;

namespace DAL
{
    class InitializerPharmacyModel:DropCreateDatabaseAlways<PharmacyModel>
    {
        protected override void Seed(PharmacyModel context)
        {
            base.Seed(context);
            USER addmin1 = new USER
            {
                ADDRESS = "k144 Nguyễn Lương Bằng",
                PASSWORD = "1234",
                USER_NAME = "admin1",
                NAME = "Ngô Văn Đông",
                DateOfBirth = DateTime.Now,
                PHONE = "0935351453",
                ROLE = true
            };
            USER staff1 = new USER
            {
                ADDRESS = "k144 Nguyễn Lương Bằng",
                PASSWORD = "1234",
                USER_NAME = "staff1",
                NAME = "Nguyễn Minh Đức",
                DateOfBirth = DateTime.Now,
                PHONE = "0935351453",
                ROLE = false
            };
            context.USERs.Add(addmin1);
            context.USERs.Add(staff1);


            context.MEDICINE_TYPE.Add(new MEDICINE_TYPE
            {
                TypeName = "Thuốc cảm lạnh, ho"
            });
            
            context.MEDICINE_TYPE.Add(new MEDICINE_TYPE
            {
                TypeName = "Giảm đau, hạ sốt"
            });

            context.UNITs.AddRange(new UNIT[] { 
                new UNIT
                {
                    NAME="Viên",
                },
                new UNIT
                {
                    NAME="Hộp"
                },
                new UNIT
                {
                    NAME="Chai",
                }
            });

            MEDICINE_TYPE t1 = new MEDICINE_TYPE
            {
                TypeName = "thuoc ke don"
            };
            MEDICINE_TYPE t2 = new MEDICINE_TYPE
            {
                TypeName = "thuoc độc"
            };

            UNIT u1 = new UNIT
            {
                NAME = "Ống",
            };

    
            MEDICINE m2 = new MEDICINE
            {
                MEDICINE_NAME = "thuoc chuot",
                BARCODE = "4562345",
                BRAND = "medico",
                CONTENT = "nuoc mieng",
                INGREDIENT = "thuoc loc 200 mL",
                MEDICINE_CODE = "pc45cdfd",
                MEDICINE_TYPE = t1,
                ORIGINAL_PRICE = 54000,
                SALE_PRICE = 63000,
                ID_SUB = "3945834",
                LOCATION = "Ke A",
                UNIT = u1,
                QUANTITY = 0,
            };

            MEDICINE m1 = new MEDICINE
            {
                BARCODE = "123456",
                MEDICINE_NAME = "Thuốc ho Prospan",
                MEDICINE_CODE = "acbs121",
                LOCATION = "Kệ A",
                ID_SUB = "145263",
                INGREDIENT = "pllplpplllpl",
                CONTENT = "ololololo",
                BRAND = "Prospan",
                QUANTITY = 1,
                ORIGINAL_PRICE = 10000,
                SALE_PRICE = 50000,
                TYPEID = 1,
                UNIT = u1,
            };


            context.MEDICINEs.AddRange(new MEDICINE[] { m1, m2 });

            STOCK s1 = new STOCK
            {
                Name="lo B",
                NOTE = "nhap ngay hom qua",
                DATE = DateTime.Now,
                PRICETOTAL = 1000000,

            };

            STOCK s2 = new STOCK
            {
                NOTE = "nhap ngay hom chu nhat",
                DATE = DateTime.Now,
                PRICETOTAL = 2000000,
                Name="lo A"
            };

      

            s1.STOCK_DETAIL.Add(new STOCK_DETAIL
            {
                MEDICINE = m2,
                dateExpire = DateTime.Now,
                ORGIGINAL_PRICE = 5000,
                QUANTITY = 50,
            });

        
            s2.STOCK_DETAIL.Add(new STOCK_DETAIL
            {
                MEDICINE = m3,
                dateExpire = DateTime.Now,
                ORGIGINAL_PRICE = 1000,
                QUANTITY = 20,
            });

            context.STOCKs.Add(s1);
            context.STOCKs.Add(s2);


            context.PHARMARCY_PROFILEs.Add(new PHARMACY_PROFILE
            {
                Address = "",
                BusinessHours="",
                Email="",
                PharmacyName="",
                PhoneNumber=""
            });


        }
    }
}
