using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    class InitailorPharmacyModel:DropCreateDatabaseAlways<PharmacyModel>
    {
        protected override void Seed(PharmacyModel context)
        {
            base.Seed(context);
            STAFF s = new STAFF
            {
                ID = "1234",
                ADDRESS = "asdfasd",
                ID_CMND = "0912834",
                PASSWORD = "1234",
                USER_NAME = "dong",
                AGE = 12,
                NAME = "Duc",
                PHONE = "0982347345"
            };
            context.STAFFs.Add(s);
        }
    }
}
