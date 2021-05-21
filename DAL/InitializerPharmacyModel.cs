using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
        }
    }
}
