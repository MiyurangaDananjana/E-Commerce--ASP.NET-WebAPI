using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.BLL
{
    public class Product_BLL
    {
        private readonly M_SHOP_DBContext _db;
        public Product_BLL(M_SHOP_DBContext db)
        {
            _db = db;
        }

        public void addNewLaptopOrDesktop(LaptopDesktopView dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.saveDataToLaptopRoDesktopDetails(dto);
        }

        public void addNewRam(ComputerRam dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.addNewRam(dto);
        }

        public void addNewVga(ComputerVga dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.addNewVga(dto);
        }


        public void saveNewHardDrive(ComputerHard dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.SaveNewHardDrive(dto);
        }

        public void saveNewProduct(ProductSpacification dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.saveNewProduct(dto);
        }

        public void saveProcessor(ComputerProcessor dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.saveNewProcessor(dto);
        }

        public void addnewComputerSeries(ComSeries dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.addnewComputerSeries(dto);
        }

        public void addnewModel(ComputreModel dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.addNewModel(dto);
        }

        internal void addNewComputer(NewComputer dto)
        {
            Product_DAL homeDAL = new Product_DAL(_db);
            homeDAL.addNewComputer(dto);
        }


        internal static seleComputerList computerDetails()
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = Product_DAL.GetComputerDetails();
            return dto;
        }

        internal static seleComputerList oderByModels(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = Product_DAL.oderByModels(modelId);
            return dto;
        }


        internal static seleComputerList oderBySeries(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = Product_DAL.oderBySeries(modelId);
            return dto;
        }

        internal static seleComputerList oderByModel(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = Product_DAL.oderByModel(modelId);
            return dto;
        }

        internal static seleComputerList oderByComputerType(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = Product_DAL.oderByComputerType(modelId);
            return dto;
        }

        internal static seleComputerList buyComputer(int modelId)
        {
            seleComputerList dto = new seleComputerList();
            dto.saleComputerDTOs = Product_DAL.buyComputer(modelId);
            return dto;
        }

    }
}
