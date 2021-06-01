﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.DTO;

namespace DAL
{
    class InitializerPharmacyModel:DropCreateDatabaseIfModelChanges<PharmacyModel>
    {
        protected override void Seed(PharmacyModel context)
        {
            base.Seed(context);
            USER addmin1 = new USER
            {
                ADDRESS = "k144 Nguyễn Lương Bằng",
                PASSWORD = "$2a$12$0iSplYFIdfT1jumcE0Akhe5eNvMKDIFjfmj0NsgOMaxVCiM7eYupa",
                USER_NAME = "admin1",
                NAME = "Ngô Văn Đông",
                DateOfBirth = DateTime.Now,
                PHONE = "0935351453",
                ROLE = true,
                DELETED = false
            };
        USER staff1 = new USER
        {
            ADDRESS = "k144 Nguyễn Lương Bằng",
            PASSWORD = "$2a$12$0iSplYFIdfT1jumcE0Akhe5eNvMKDIFjfmj0NsgOMaxVCiM7eYupa",
            USER_NAME = "staff1",
            NAME = "Nguyễn Minh Đức",
            DateOfBirth = DateTime.Now,
            PHONE = "0935351453",
            ROLE = false,
            DELETED = false
        };
            context.USERs.Add(addmin1);
            context.USERs.Add(staff1);


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

            UNIT u2 = new UNIT
            {
                NAME = "Viên",
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
                QUANTITY = 50,
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
                QUANTITY = 55,
                ORIGINAL_PRICE = 10000,
                SALE_PRICE = 50000,
                TYPEID = 1,
                UNIT = u2,
            };

            MEDICINE m3 = new MEDICINE
            {
                BARCODE = "1234134",
                MEDICINE_NAME = "Thuốc ho con cop",
                MEDICINE_CODE = "acbs121",
                LOCATION = "Kệ b",
                ID_SUB = "145263",
                INGREDIENT = "pllplpplllpl",
                CONTENT = "ololololo",
                BRAND = "Prospan",
                QUANTITY = 20,
                ORIGINAL_PRICE = 15000,
                SALE_PRICE = 20000,
                MEDICINE_TYPE=t2,
                UNIT = u2,
            };


            context.MEDICINEs.AddRange(new MEDICINE[] { m1, m2,m3 });

            SUPPLIER su1 = new SUPPLIER
            {
                NAME = "Vinmec",
                EMAIL = "vinmec@gmail.com",
                ADDRESS = "177 Trường Chinh, Đà Nẵng",
                PHONE_NUMBER = "097834753"
            };

            SUPPLIER su2 = new SUPPLIER
            {
                NAME = "ACBmedicine",
                EMAIL = "ACB@gmail.com",
                ADDRESS = "10 Nguyễn Tất Thành, Đà Nẵng",
                PHONE_NUMBER = "097833453"
            };

            STOCK s1 = new STOCK
            {
                Name="lo B",
                NOTE = "nhap ngay hom qua",
                DATE = DateTime.Now,
                PRICETOTAL = 1000000,
                SUPPLIER=su1

            };

            STOCK s2 = new STOCK
            {
                NOTE = "nhap ngay hom chu nhat",
                DATE = DateTime.Now,
                PRICETOTAL = 2000000,
                Name="lo A",
                SUPPLIER = su2
            };

      

            s1.STOCK_DETAIL.Add(new STOCK_DETAIL
            {
                MEDICINE = m2,
                dateExpire = DateTime.Now,
                ORGIGINAL_PRICE = 5000,
                QUANTITY = 50,
            });

            s1.STOCK_DETAIL.Add(new STOCK_DETAIL
            {
                MEDICINE = m1,
                dateExpire = DateTime.Now,
                ORGIGINAL_PRICE = 4000,
                QUANTITY = 20,
            });

            s2.STOCK_DETAIL.Add(new STOCK_DETAIL
            {
                MEDICINE = m1,
                dateExpire = DateTime.Now,
                ORGIGINAL_PRICE = 10000,
                QUANTITY = 35,
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


            CUSTOMER c1 = new CUSTOMER
            {
                Customer_name = "Ngô Văn Đông",
                Phone = "092347858"
            };

            CUSTOMER c2 = new CUSTOMER
            {
                Customer_name = "Nguyễn Minh Đức",
                Phone = "012375834"
            };
            CUSTOMER c3 = new CUSTOMER
            {
                Customer_name = "Koh",
                Phone = "093578747"
            };

            context.CUSTOMERs.AddRange(new CUSTOMER[] { c1, c2, c3 });

            SAMPLE sa1 = new SAMPLE
            {
                NAME = "Thuốc ho",
                PRESCRIPTION = "uống sáng tối, ăn trước khi uống"

            };

            sa1.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
            {
                MEDICINE = m1,
                QTY = 3,
            });
            sa1.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
            {
                MEDICINE = m2,
                QTY = 2
            });

            SAMPLE sa2 = new SAMPLE
            {
                NAME = "Thuốc dạ dày",
                PRESCRIPTION = "uống trước khi ăn, sáng tối"
            };

            sa2.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
            {
                MEDICINE = m1,
                QTY = 10
            });
            sa2.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
            {
                MEDICINE = m3,
                QTY = 3
            });

            context.SAMPLEs.AddRange(new SAMPLE[] { sa1, sa2 });



        }
    }
}
