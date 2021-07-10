using System;
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


            
        }
    }
}
