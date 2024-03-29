﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace e_com_RSEt_API.Models
{
    public partial class M_SHOP_DBContext : DbContext
    {
        public M_SHOP_DBContext()
        {
        }

        public M_SHOP_DBContext(DbContextOptions<M_SHOP_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogins { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ComSeries> ComSeries { get; set; } = null!;
        public virtual DbSet<ComputerHard> ComputerHards { get; set; } = null!;
        public virtual DbSet<ComputerManufacturer> ComputerManufacturers { get; set; } = null!;
        public virtual DbSet<ComputerO> ComputerOs { get; set; } = null!;
        public virtual DbSet<ComputerOder> ComputerOders { get; set; } = null!;
        public virtual DbSet<ComputerProcessor> ComputerProcessors { get; set; } = null!;
        public virtual DbSet<ComputerRam> ComputerRams { get; set; } = null!;
        public virtual DbSet<ComputerType> ComputerTypes { get; set; } = null!;
        public virtual DbSet<ComputerVga> ComputerVgas { get; set; } = null!;
        public virtual DbSet<ComputreModel> ComputreModels { get; set; } = null!;
        public virtual DbSet<CustomerAddressTb> CustomerAddressTbs { get; set; } = null!;
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; } = null!;
        public virtual DbSet<CustomerEmail> CustomerEmails { get; set; } = null!;
        public virtual DbSet<HardDriveType> HardDriveTypes { get; set; } = null!;
        public virtual DbSet<Headset> Headsets { get; set; } = null!;
        public virtual DbSet<Keyboard> Keyboards { get; set; } = null!;
        public virtual DbSet<LaptopDesktopView> LaptopDesktopViews { get; set; } = null!;
        public virtual DbSet<Mouse> Mouses { get; set; } = null!;
        public virtual DbSet<NewComputer> NewComputers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSpacification> ProductSpacifications { get; set; } = null!;
        public virtual DbSet<ShipingMethod> ShipingMethods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2DVOUG1\\SQLEXPRESS;Database=M_SHOP_DB;Trusted_Connection=True;");
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

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_DESCRIPTION");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
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

            modelBuilder.Entity<ComputerHard>(entity =>
            {
                entity.HasKey(e => e.HardId)
                    .HasName("PK__COMPUTER__A56671DA0A7E7E82");

                entity.ToTable("COMPUTER_HARD");

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

            modelBuilder.Entity<ComputerO>(entity =>
            {
                entity.HasKey(e => e.OsId);

                entity.ToTable("COMPUTER_OS");

                entity.Property(e => e.OsId).HasColumnName("OS_ID");

                entity.Property(e => e.OsName)
                    .HasMaxLength(50)
                    .HasColumnName("OS_NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");
            });

            modelBuilder.Entity<ComputerOder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_COPM_ODER");

                entity.ToTable("COMPUTER_ODER");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.AntivirusGrdId).HasColumnName("ANTIVIRUS_GRD_ID");

                entity.Property(e => e.ApprovedBy).HasColumnName("APPROVED_BY");

                entity.Property(e => e.BullingAddressId).HasColumnName("BULLING_ADDRESS_ID");

                entity.Property(e => e.CusId).HasColumnName("CUS_ID");

                entity.Property(e => e.OderDate)
                    .HasColumnType("date")
                    .HasColumnName("ODER_DATE");

                entity.Property(e => e.OderStatus).HasColumnName("ODER_STATUS");

                entity.Property(e => e.OsId).HasColumnName("OS_ID");

                entity.Property(e => e.ProcessorId).HasColumnName("PROCESSOR_ID");

                entity.Property(e => e.RamId).HasColumnName("RAM_ID");

                entity.Property(e => e.ShipingAddressId).HasColumnName("SHIPING_ADDRESS_ID");

                entity.Property(e => e.ShipingMethod).HasColumnName("SHIPING_METHOD");

                entity.Property(e => e.VgaId).HasColumnName("VGA_ID");
            });

            modelBuilder.Entity<ComputerProcessor>(entity =>
            {
                entity.HasKey(e => e.ProcessorId)
                    .HasName("PK__COMPUTER__8758DBE8D616FB68");

                entity.ToTable("COMPUTER_PROCESSOR");

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

            modelBuilder.Entity<ComputerRam>(entity =>
            {
                entity.HasKey(e => e.RamId)
                    .HasName("PK__COMPUTER__4C870AB60A85E037");

                entity.ToTable("COMPUTER_RAM");

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

            modelBuilder.Entity<ComputerType>(entity =>
            {
                entity.ToTable("COMPUTER_TYPE");

                entity.Property(e => e.ComputerTypeId).HasColumnName("COMPUTER_TYPE_ID");

                entity.Property(e => e.ComputerType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPUTER_TYPE");
            });

            modelBuilder.Entity<ComputerVga>(entity =>
            {
                entity.HasKey(e => e.VgaId)
                    .HasName("PK__COMPUTER__30C5FE98D2F39A5E");

                entity.ToTable("COMPUTER_VGA");

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

            modelBuilder.Entity<ComputreModel>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK_COM_MODEL");

                entity.ToTable("COMPUTRE_MODEL");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODEL_NAME");

                entity.Property(e => e.SeriesId).HasColumnName("SERIES_ID");
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

                entity.Property(e => e.ConfiremCode).HasColumnName("CONFIREM_CODE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmailValidate).HasColumnName("EMAIL_VALIDATE");

                entity.Property(e => e.FristName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FRIST_NAME");

                entity.Property(e => e.Ip)
                    .HasMaxLength(60)
                    .HasColumnName("IP");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_LOGIN_TIME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LogInOut).HasColumnName("LOG_IN_OUT");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.ProfileImagePath)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROFILE_IMAGE_PATH");

                entity.Property(e => e.Statest).HasColumnName("STATEST");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<CustomerEmail>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.ToTable("CUSTOMER_EMAIL");

                entity.Property(e => e.EmailId).HasColumnName("EMAIL_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .HasMaxLength(100)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Statest).HasColumnName("STATEST");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
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

            modelBuilder.Entity<Headset>(entity =>
            {
                entity.ToTable("HEADSETS");

                entity.Property(e => e.HeadsetId).HasColumnName("HEADSET_ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.Compatibility)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPATIBILITY");

                entity.Property(e => e.Connectivity).HasColumnName("CONNECTIVITY");

                entity.Property(e => e.FrequencyResponse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FREQUENCY_RESPONSE");

                entity.Property(e => e.Impedance)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMPEDANCE");

                entity.Property(e => e.Microphone).HasColumnName("MICROPHONE");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.Sensitivity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SENSITIVITY");

                entity.Property(e => e.Warranty)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WARRANTY");

                entity.Property(e => e.Weight)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WEIGHT");
            });

            modelBuilder.Entity<Keyboard>(entity =>
            {
                entity.ToTable("KEYBOARDS");

                entity.Property(e => e.KeyboardId)
                    .ValueGeneratedNever()
                    .HasColumnName("KEYBOARD_ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.Compatibility)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPATIBILITY");

                entity.Property(e => e.Connectivity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONNECTIVITY");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.StockQuantity).HasColumnName("STOCK_QUANTITY");
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

            modelBuilder.Entity<Mouse>(entity =>
            {
                entity.ToTable("MOUSE");

                entity.Property(e => e.MouseId)
                    .ValueGeneratedNever()
                    .HasColumnName("MOUSE_ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.Connectivity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONNECTIVITY");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.SensorType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SENSOR_TYPE");

                entity.Property(e => e.StockQuantity).HasColumnName("STOCK_QUANTITY");
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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ORDER_DATE");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("TOTAL_PRICE");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("ORDER_DETAILS");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_ID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_DESCRIPTION");

                entity.Property(e => e.ProductImage).HasColumnName("PRODUCT_IMAGE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.StockQuantity).HasColumnName("STOCK_QUANTITY");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CATEGORY_ID");

                entity.HasMany(d => d.Keyboards)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductKeyboard",
                        l => l.HasOne<Keyboard>().WithMany().HasForeignKey("KeyboardId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PK_KEYBOARD_ID"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PK_PRODUCT_ID"),
                        j =>
                        {
                            j.HasKey("ProductId", "KeyboardId");

                            j.ToTable("PRODUCT_KEYBOARDS");

                            j.IndexerProperty<int>("ProductId").HasColumnName("PRODUCT_ID");

                            j.IndexerProperty<int>("KeyboardId").HasColumnName("KEYBOARD_ID");
                        });

                entity.HasMany(d => d.Mice)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductMice",
                        l => l.HasOne<Mouse>().WithMany().HasForeignKey("MouseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PM_MOUSE_ID"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PM_PRODUCT_ID"),
                        j =>
                        {
                            j.HasKey("ProductId", "MouseId");

                            j.ToTable("PRODUCT_MICE");

                            j.IndexerProperty<int>("ProductId").HasColumnName("PRODUCT_ID");

                            j.IndexerProperty<int>("MouseId").HasColumnName("MOUSE_ID");
                        });
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
