using e_com_RSEt_API.Models;
using System.Linq;

namespace e_com_RSEt_API.DAL
{
    public class HomeDAL
    {
        private readonly E_COM_WEBContext _db;



        public HomeDAL(E_COM_WEBContext db)
        {
            _db = db;
        }
        public void addNewRam(CumputerRam dto)
        {

            _db.CumputerRams.Add(dto);
            _db.SaveChanges();

        }

        public void addNewVga(CumputerVga dto)
        {

            _db.CumputerVgas.Add(dto);
            _db.SaveChanges();
        }

        public void saveAdminUser(AdminLogin dto)
        {

            _db.AdminLogins.Add(dto);
            _db.SaveChanges();
        }

        public void saveAntivirusGard(AntivirusGard antivirus)
        {

            _db.AntivirusGards.Add(antivirus);
            _db.SaveChanges();
        }
        public void saveCustomerAddress(CustomerAddressTb dto)
        {

            _db.CustomerAddressTbs.Add(dto);
            _db.SaveChanges();
        }
        public void saveCustomerDataBase(CustomerDetail dto)
        {

            _db.CustomerDetails.Add(dto);
            _db.SaveChanges();
        }

        public void saveDataToLaptopRoDesktopDetails(LaptopDesktopView dto)
        {

            _db.LaptopDesktopViews.Add(dto);
            _db.SaveChanges();
        }

        public void SaveNewHardDrive(CumputerHard dto)
        {

            _db.CumputerHards.Add(dto);
            _db.SaveChanges();
        }

        public void saveNewProcessor(CumputerProcessor dto)
        {

            _db.CumputerProcessors.Add(dto);
            _db.SaveChanges();
        }

        public void saveNewProduct(ProductSpacification dto)
        {
            throw new NotImplementedException();
        }

        public void addnewComputerSeries(ComSeries dto)
        {
            _db.ComSeries.Add(dto);
            _db.SaveChanges();
        }

        public void addNewModel(ComModel dto)
        {
            _db.ComModels.Add(dto);
            _db.SaveChanges();
        }

        public void addNewComputer(NewComputer dto)
        {
            _db.NewComputers.Add(dto);
            _db.SaveChanges();
        }

        internal static List<saleComputerDTO> GetComputerDetails()
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List =( from computerDetails in db.ComSeries
                       join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                       join computeModel in db.ComModels on computerDetails.SeriesId equals computeModel.SeriesId
                       join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                       orderby newComputer.ComId descending
                       select new
                       {
                           id = computerDetails.ComputerTypeId,
                           mf = mf.ManufacturersName,
                           computerSeries = computerDetails.SeriesName,
                           computeModel = computeModel.ModelName,
                           computerPrice = newComputer.Price,
                           description = newComputer.Description,
                           computerImagePath = newComputer.ImagePath,
                       }).Take(8);

            foreach (var item in List)
            {
                saleComputerDTO dto = new saleComputerDTO();
                dto.comId = item.id;
                dto.Mf = item.mf;
                dto.Series = item.computerSeries;
                dto.Model = item.computeModel;
                dto.Description = item.description;
                dto.Price = (decimal)(item.computerPrice ?? 00);
                dto.ImagePath = item.computerImagePath;
                saleComputerDTOs.Add(dto);

            }
            return saleComputerDTOs;

        }

        internal static List<saleComputerDTO> oderByModels(int modelId)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        where computerDetails.MfId == modelId
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComModels on computerDetails.SeriesId equals computeModel.SeriesId 
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId 
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = computerDetails.ComputerTypeId,
                            mf = mf.ManufacturersName,
                            computerSeries = computerDetails.SeriesName,
                            computeModel = computeModel.ModelName,
                            computerPrice = newComputer.Price,
                            description = newComputer.Description,
                            computerImagePath = newComputer.ImagePath,
                        }).Take(8);

            foreach (var item in List)
            {
                saleComputerDTO dto = new saleComputerDTO();
                dto.comId = item.id;
                dto.Mf = item.mf;
                dto.Series = item.computerSeries;
                dto.Model = item.computeModel;
                dto.Description = item.description;
                dto.Price = (decimal)(item.computerPrice ?? 00);
                dto.ImagePath = item.computerImagePath;
                saleComputerDTOs.Add(dto);

            }
            return saleComputerDTOs;
        }

        internal static List<saleComputerDTO> oderBySeries(int modelId)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        where computerDetails.SeriesId == modelId
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = computerDetails.ComputerTypeId,
                            mf = mf.ManufacturersName,
                            computerSeries = computerDetails.SeriesName,
                            computeModel = computeModel.ModelName,
                            computerPrice = newComputer.Price,
                            description = newComputer.Description,
                            computerImagePath = newComputer.ImagePath,
                        }).Take(8);

            foreach (var item in List)
            {
                saleComputerDTO dto = new saleComputerDTO();
                dto.comId = item.id;
                dto.Mf = item.mf;
                dto.Series = item.computerSeries;
                dto.Model = item.computeModel;
                dto.Description = item.description;
                dto.Price = (decimal)(item.computerPrice ?? 00);
                dto.ImagePath = item.computerImagePath;
                saleComputerDTOs.Add(dto);

            }
            return saleComputerDTOs;
        }

        internal static List<saleComputerDTO> oderByModel(int modelId)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        where newComputer.ModelId == modelId
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = computerDetails.ComputerTypeId,
                            mf = mf.ManufacturersName,
                            computerSeries = computerDetails.SeriesName,
                            computeModel = computeModel.ModelName,
                            computerPrice = newComputer.Price,
                            description = newComputer.Description,
                            computerImagePath = newComputer.ImagePath,
                        }).Take(8);

            foreach (var item in List)
            {
                saleComputerDTO dto = new saleComputerDTO();
                dto.comId = item.id;
                dto.Mf = item.mf;
                dto.Series = item.computerSeries;
                dto.Model = item.computeModel;
                dto.Description = item.description;
                dto.Price = (decimal)(item.computerPrice ?? 00);
                dto.ImagePath = item.computerImagePath;
                saleComputerDTOs.Add(dto);

            }
            return saleComputerDTOs;
        }

        internal static List<saleComputerDTO> oderByComputerType(int modelId)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        where computerDetails.ComputerTypeId == modelId
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = computerDetails.ComputerTypeId,
                            mf = mf.ManufacturersName,
                            computerSeries = computerDetails.SeriesName,
                            computeModel = computeModel.ModelName,
                            computerPrice = newComputer.Price,
                            description = newComputer.Description,
                            computerImagePath = newComputer.ImagePath,
                        }).Take(8);

            foreach (var item in List)
            {
                saleComputerDTO dto = new saleComputerDTO();
                dto.comId = item.id;
                dto.Mf = item.mf;
                dto.Series = item.computerSeries;
                dto.Model = item.computeModel;
                dto.Description = item.description;
                dto.Price = (decimal)(item.computerPrice ?? 00);
                dto.ImagePath = item.computerImagePath;
                saleComputerDTOs.Add(dto);

            }
            return saleComputerDTOs;
        }

        internal static List<saleComputerDTO> buyComputer(int modelId)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        where newComputer.ComId == modelId

                        orderby newComputer.ComId descending
                        select new
                        {
                            id = computerDetails.ComputerTypeId,
                            mf = mf.ManufacturersName,
                            computerSeries = computerDetails.SeriesName,
                            computeModel = computeModel.ModelName,
                            computerPrice = newComputer.Price,
                            description = newComputer.Description,
                            computerImagePath = newComputer.ImagePath,
                        }).Take(8);

            foreach (var item in List)
            {
                saleComputerDTO dto = new saleComputerDTO();
                dto.comId = item.id;
                dto.Mf = item.mf;
                dto.Series = item.computerSeries;
                dto.Model = item.computeModel;
                dto.Description = item.description;
                dto.Price = (decimal)(item.computerPrice ?? 00);
                dto.ImagePath = item.computerImagePath;
                saleComputerDTOs.Add(dto);

            }
            return saleComputerDTOs;
        }
    }
}
