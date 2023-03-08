using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace e_com_RSEt_API.Models
{
    public partial class E_COM_WEBContext : DbContext
    {
        public E_COM_WEBContext()
        {
        }

        public E_COM_WEBContext(DbContextOptions<E_COM_WEBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogins { get; set; } = null!;
        public virtual DbSet<AntivirusGard> AntivirusGards { get; set; } = null!;
        public virtual DbSet<ComModel> ComModels { get; set; } = null!;
        public virtual DbSet<ComSeries> ComSeries { get; set; } = null!;
        public virtual DbSet<ComputerManufacturer> ComputerManufacturers { get; set; } = null!;
        public virtual DbSet<ComputerType> ComputerTypes { get; set; } = null!;
        public virtual DbSet<CumputerHard> CumputerHards { get; set; } = null!;
        public virtual DbSet<CumputerProcessor> CumputerProcessors { get; set; } = null!;
        public virtual DbSet<CumputerRam> CumputerRams { get; set; } = null!;
        public virtual DbSet<CumputerVga> CumputerVgas { get; set; } = null!;
        public virtual DbSet<CustomerAddressTb> CustomerAddressTbs { get; set; } = null!;
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; } = null!;
        public virtual DbSet<HardDriveType> HardDriveTypes { get; set; } = null!;
        public virtual DbSet<LaptopDesktopView> LaptopDesktopViews { get; set; } = null!;
        public virtual DbSet<NewComputer> NewComputers { get; set; } = null!;
        public virtual DbSet<ProductSpacification> ProductSpacifications { get; set; } = null!;
        public virtual DbSet<ShipingMethod> ShipingMethods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2DVOUG1\\SQLEXPRESS;Database=E_COM_WEB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("ADMIN_LOGIN");

                entity.Property(e => e.AdminId).HasColumnName("ADMIN_ID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber).HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<AntivirusGard>(entity =>
            {
                entity.HasKey(e => e.AntivirusId);

                entity.ToTable("ANTIVIRUS_GARD");

                entity.Property(e => e.AntivirusId).HasColumnName("ANTIVIRUS_ID");

                entity.Property(e => e.AntivirusName)
                    .HasMaxLength(50)
                    .HasColumnName("ANTIVIRUS_NAME");

                entity.Property(e => e.Price).HasColumnName("PRICE");
            });

            modelBuilder.Entity<ComModel>(entity =>
            {
                entity.HasKey(e => e.ModelId);

                entity.ToTable("COM_MODEL");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODEL_NAME");

                entity.Property(e => e.SeriesId).HasColumnName("SERIES_ID");
            });

            modelBuilder.Entity<ComSeries>(entity =>
            {
                entity.HasKey(e => e.SeriesId);

                entity.ToTable("COM_SERIES");

                entity.Property(e => e.SeriesId).HasColumnName("SERIES_ID");

                entity.Property(e => e.ComputerTypeId).HasColumnName("COMPUTER_TYPE_ID");

                entity.Property(e => e.MfId).HasColumnName("MF_ID");

                entity.Property(e => e.SeriesName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SERIES_NAME");
            });

            modelBuilder.Entity<ComputerManufacturer>(entity =>
            {
                entity.HasKey(e => e.ManufacturersId);

                entity.ToTable("COMPUTER_MANUFACTURERS");

                entity.Property(e => e.ManufacturersId).HasColumnName("MANUFACTURERS_ID");

                entity.Property(e => e.ManufacturersName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MANUFACTURERS_NAME");
            });

            modelBuilder.Entity<ComputerType>(entity =>
            {
                entity.ToTable("COMPUTER_TYPE");

                entity.Property(e => e.ComputerTypeId).HasColumnName("COMPUTER_TYPE_ID");

                entity.Property(e => e.ComputerType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPUTER_TYPE");
            });

            modelBuilder.Entity<CumputerHard>(entity =>
            {
                entity.HasKey(e => e.HardId)
                    .HasName("PK__CUMPUTER__A56671DAA2B90DD7");

                entity.ToTable("CUMPUTER_HARD");

                entity.Property(e => e.HardId).HasColumnName("HARD_ID");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.HardName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HARD_NAME");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<CumputerProcessor>(entity =>
            {
                entity.HasKey(e => e.ProcessorId)
                    .HasName("PK__CUMPUTER__8758DBE81DC64B18");

                entity.ToTable("CUMPUTER_PROCESSOR");

                entity.Property(e => e.ProcessorId).HasColumnName("PROCESSOR_ID");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.PriceDouble).HasColumnName("PRICE_DOUBLE");

                entity.Property(e => e.ProcessorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROCESSOR_NAME");
            });

            modelBuilder.Entity<CumputerRam>(entity =>
            {
                entity.HasKey(e => e.RamId)
                    .HasName("PK__CUMPUTER__4C870AB6A8E18C41");

                entity.ToTable("CUMPUTER_RAM");

                entity.Property(e => e.RamId).HasColumnName("RAM_ID");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.RamName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RAM_NAME");
            });

            modelBuilder.Entity<CumputerVga>(entity =>
            {
                entity.HasKey(e => e.VgaId)
                    .HasName("PK__CUMPUTER__30C5FE989C344978");

                entity.ToTable("CUMPUTER_VGA");

                entity.Property(e => e.VgaId).HasColumnName("VGA_ID");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.VgaName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VGA_NAME");
            });

            modelBuilder.Entity<CustomerAddressTb>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("CUSTOMER_ADDRESS_TB");

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS_LINE_1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS_LINE_2");

                entity.Property(e => e.City).HasColumnName("CITY");

                entity.Property(e => e.CustomerCode).HasColumnName("CUSTOMER_CODE");

                entity.Property(e => e.PostalCode).HasColumnName("POSTAL_CODE");

                entity.Property(e => e.Provition).HasColumnName("PROVITION");
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("CUSTOMER_DETAILS");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FristName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FRIST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Statest).HasColumnName("STATEST");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<HardDriveType>(entity =>
            {
                entity.HasKey(e => e.HardDriveType1);

                entity.ToTable("HARD_DRIVE_TYPE");

                entity.Property(e => e.HardDriveType1)
                    .ValueGeneratedNever()
                    .HasColumnName("HARD_DRIVE_TYPE");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<LaptopDesktopView>(entity =>
            {
                entity.HasKey(e => e.CumputerId);

                entity.ToTable("LAPTOP_DESKTOP_VIEW");

                entity.Property(e => e.CumputerId).HasColumnName("CUMPUTER_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(50)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.LD)
                    .HasMaxLength(50)
                    .HasColumnName("L/D");

                entity.Property(e => e.Manufacture)
                    .HasMaxLength(50)
                    .HasColumnName("MANUFACTURE");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .HasColumnName("MODEL");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Year)
                    .HasColumnType("date")
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<NewComputer>(entity =>
            {
                entity.HasKey(e => e.ComId);

                entity.ToTable("NEW_COMPUTER");

                entity.Property(e => e.ComId).HasColumnName("COM_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(50)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.States).HasColumnName("STATES");
            });




            modelBuilder.Entity<ProductSpacification>(entity =>
            {
                entity.HasKey(e => e.ComputerId);

                entity.ToTable("PRODUCT_SPACIFICATION");

                entity.Property(e => e.ComputerId).HasColumnName("COMPUTER_ID");

                entity.Property(e => e.Antivirus).HasColumnName("ANTIVIRUS");

                entity.Property(e => e.Bt)
                    .HasMaxLength(50)
                    .HasColumnName("BT");

                entity.Property(e => e.ComouterType).HasColumnName("COMOUTER_TYPE");

                entity.Property(e => e.Display)
                    .HasMaxLength(50)
                    .HasColumnName("DISPLAY");

                entity.Property(e => e.Hard).HasColumnName("HARD");

                entity.Property(e => e.ImgePath)
                    .HasMaxLength(50)
                    .HasColumnName("IMGE_PATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("NAME");

                entity.Property(e => e.Processor).HasColumnName("PROCESSOR");

                entity.Property(e => e.Ram).HasColumnName("RAM");

                entity.Property(e => e.Warranty).HasColumnName("WARRANTY");

                entity.Property(e => e.Wifi)
                    .HasMaxLength(50)
                    .HasColumnName("WIFI");
            });

            modelBuilder.Entity<ShipingMethod>(entity =>
            {
                entity.ToTable("SHIPING_METHOD");

                entity.Property(e => e.ShipingMethodId).HasColumnName("SHIPING_METHOD_ID");

                entity.Property(e => e.ShipingMethod1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPING_METHOD");
            });

            modelBuilder.HasSequence("ID_Seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
