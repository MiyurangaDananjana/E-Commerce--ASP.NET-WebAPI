using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.BLL
{
    public class HomeBLL
    {
        private readonly E_COM_WEBContext _db;

        public HomeBLL(E_COM_WEBContext db)
        {
            _db = db;
        }

        public void addNewAdmin(AdminLogin dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveAdminUser(dto);

        }

        public void addNewLaptopOrDesktop(LaptopDesktopView dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveDataToLaptopRoDesktopDetails(dto);
        }

        public void addNewRam(CumputerRam dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.addNewRam(dto);
        }

        public void addNewVga(CumputerVga dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.addNewVga(dto);
        }

        public void saveAntivirusGard(AntivirusGard antivirus)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveAntivirusGard(antivirus);
        }

        public void saveCustomer(CustomerDetail dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveCustomerDataBase(dto);
        }

        public void saveCustomerAddress(CustomerAddressTb dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveCustomerAddress(dto);
        }

        public void saveNewHardDrive(CumputerHard dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.SaveNewHardDrive(dto);
        }

        public void saveNewProduct(ProductSpacification dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveNewProduct(dto);
        }

        public void saveProcessor(CumputerProcessor dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.saveNewProcessor(dto);
        }

        public void  addnewComputerSeries(ComSeries dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.addnewComputerSeries(dto);
        }

        public void addnewModel(ComModel dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.addNewModel(dto);
        }

        internal void addNewComputer(NewComputer dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.addNewComputer(dto);
        }

        internal static seleComputerList computerDetails()
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = HomeDAL.GetComputerDetails();
            return dto;
        }

        internal static seleComputerList oderByModels(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = HomeDAL.oderByModels(modelId);
            return dto;
        }

        internal static seleComputerList oderBySeries(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = HomeDAL.oderBySeries(modelId);
            return dto;
        }

        internal static seleComputerList oderByModel(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = HomeDAL.oderByModel(modelId);
            return dto;
        }

        internal static seleComputerList oderByComputerType(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = HomeDAL.oderByComputerType(modelId);
            return dto;
        }

        internal static seleComputerList buyComputer(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = HomeDAL.buyComputer(modelId);
            return dto;
        }

        internal void AddNewComputerReq(CopmOder dto)
        {
            HomeDAL homeDAL = new HomeDAL(_db);
            homeDAL.AddNewComputerReq(dto);

        }
    }
}
