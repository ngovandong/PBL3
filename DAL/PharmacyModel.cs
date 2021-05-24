using DAL.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class PharmacyModel : DbContext
    {
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public PharmacyModel()
            : base("data source=LAPTOP-UH428P8U\\SQLEXPRESS;initial catalog=doan3;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer<PharmacyModel>(new InitializerPharmacyModel());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<INVOICE> INVOICEs { get; set; }
        public virtual DbSet<INVOICE_DETAIL> INVOICE_DETAIL { get; set; }
        public virtual DbSet<LISTMEDICINE> LISTMEDICINEs { get; set; }
        public virtual DbSet<MEDICINE> MEDICINEs { get; set; }
        public virtual DbSet<MEDICINE_TYPE> MEDICINE_TYPE { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<STOCK> STOCKs { get; set; }
        public virtual DbSet<STOCK_DETAIL> STOCK_DETAIL { get; set; }
        public virtual DbSet<UNIT> UNITs { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIERs { get; set; }
        public virtual DbSet<PHARMACY_PROFILE> PHARMARCY_PROFILEs { get; set; }
        public virtual DbSet<SAMPLE> SAMPLEs { get; set; }
        public virtual DbSet<SAMPLE_DETAIL> SAMPLE_DETAILs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.INVOICEs)
                .WithOptional(e => e.CUSTOMER)
                .HasForeignKey(e => e.ID_CUSTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INVOICE>()
                .HasMany(e => e.INVOICE_DETAIL)
                .WithRequired(e => e.INVOICE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEDICINE>()
                .HasMany(e => e.INVOICE_DETAIL)
                .WithRequired(e => e.MEDICINE)
                .HasForeignKey(e => e.ID_MEDICINE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEDICINE>()
                .HasMany(e => e.STOCK_DETAIL)
                .WithRequired(e => e.MEDICINE)
                .HasForeignKey(e => e.ID_MEDICINE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEDICINE_TYPE>()
                .HasMany(e => e.MEDICINEs)
                .WithOptional(e => e.MEDICINE_TYPE)
                .HasForeignKey(e => e.TYPEID);



            modelBuilder.Entity<USER>()
                .HasMany(e => e.INVOICEs)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<STOCK>()
                .Property(e => e.NOTE)
                .IsUnicode(false);

            modelBuilder.Entity<STOCK>()
                .HasMany(e => e.STOCK_DETAIL)
                .WithRequired(e => e.STOCK)
                .HasForeignKey(e => e.ID_STOCK)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<UNIT>()
                .HasMany(e => e.MEDICINEs)
                .WithRequired(e => e.UNIT)
                .HasForeignKey(e => e.UNIT_ID);
        }
    }
}
