using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.DAL
{
    public class Product_DAL
    {

        private readonly M_SHOP_DBContext _db;



        public Product_DAL(M_SHOP_DBContext db)
        {
            _db = db;
        }
        public void addNewRam(ComputerRam dto)
        {

            _db.ComputerRams.Add(dto);
            _db.SaveChanges();

        }

        public void addNewVga(ComputerVga dto)
        {

            _db.ComputerVgas.Add(dto);
            _db.SaveChanges();
        }
        public void saveDataToLaptopRoDesktopDetails(LaptopDesktopView dto)
        {

            _db.LaptopDesktopViews.Add(dto);
            _db.SaveChanges();
        }

        public void SaveNewHardDrive(ComputerHard dto)
        {

            _db.ComputerHards.Add(dto);
            _db.SaveChanges();
        }

        public void saveNewProcessor(ComputerProcessor dto)
        {

            _db.ComputerProcessors.Add(dto);
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

        public void addNewModel(ComputreModel dto)
        {
            _db.ComputreModels.Add(dto);
            _db.SaveChanges();
        }

        public void addNewComputer(NewComputer dto)
        {
            _db.NewComputers.Add(dto);
            _db.SaveChanges();
        }



        internal static List<saleComputerDTO> GetComputerDetails()
        {
            M_SHOP_DBContext db = new M_SHOP_DBContext();

            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();

            var List = (from computerDetails in db.ComSeries
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComputreModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = newComputer.ComId,
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
            M_SHOP_DBContext db = new M_SHOP_DBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        where computerDetails.MfId == modelId
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComputreModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = newComputer.ComId,
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
            M_SHOP_DBContext db = new M_SHOP_DBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        where computerDetails.SeriesId == modelId
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComputreModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = newComputer.ComId,
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
            M_SHOP_DBContext db = new M_SHOP_DBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries

                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComputreModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        where newComputer.ModelId == modelId
                        orderby newComputer.ComId descending
                        select new
                        {
                            id = newComputer.ComId,
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
            M_SHOP_DBContext db = new M_SHOP_DBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        where computerDetails.ComputerTypeId == modelId
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComputreModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId

                        orderby newComputer.ComId descending
                        select new
                        {
                            id = newComputer.ComId,
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
            M_SHOP_DBContext db = new M_SHOP_DBContext();
            List<saleComputerDTO> saleComputerDTOs = new List<saleComputerDTO>();
            var List = (from computerDetails in db.ComSeries
                        join mf in db.ComputerManufacturers on computerDetails.MfId equals mf.ManufacturersId
                        join computeModel in db.ComputreModels on computerDetails.SeriesId equals computeModel.SeriesId
                        join newComputer in db.NewComputers on computeModel.ModelId equals newComputer.ModelId
                        where newComputer.ComId == modelId

                        orderby newComputer.ComId descending
                        select new
                        {
                            id = newComputer.ComId,
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
