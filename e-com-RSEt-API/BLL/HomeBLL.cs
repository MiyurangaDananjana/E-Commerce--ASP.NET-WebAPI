using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.BLL
{
    public class HomeBLL
    {
        internal static void addNewAdmin(AdminLogin dto)
        {
            HomeDAL.saveAdminUser(dto);
        }

        internal static void addNewLaptopOrDesktop(LaptopDesktopView dto)
        {
            HomeDAL.saveDataToLaptopRoDesktopDetails(dto);
        }

        internal static void addNewRam(CumputerRam dto)
        {
            HomeDAL.addNewRam(dto);
        }

        internal static void addNewVga(CumputerVga dto)
        {
            HomeDAL.addNewVga(dto);
        }

        internal static void saveAntivirusGard(AntivirusGard antivirus)
        {
            HomeDAL.saveAntivirusGard(antivirus);
        }

        internal static void saveCustomer(CustomerDetail dto)
        {
            HomeDAL.saveCustomerDataBase(dto);
        }

        internal static void saveCustomerAddress(CustomerAddressTb dto)
        {
            HomeDAL.saveCustomerAddress(dto);
        }

        internal static void saveNewHardDrive(CumputerHard dto)
        {
            HomeDAL.SaveNewHardDrive(dto);
        }

        internal static void saveNewProduct(ProductSpacification dto)
        {
            HomeDAL.saveNewProduct(dto);
        }

        internal static void saveProcessor(CumputerProcessor dto)
        {
            HomeDAL.saveNewProcessor(dto);
        }
    }
}
