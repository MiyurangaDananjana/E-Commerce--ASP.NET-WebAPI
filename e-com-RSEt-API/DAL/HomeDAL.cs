using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.DAL
{
    public class HomeDAL
    {
        internal static void addNewRam(CumputerRam dto)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.CumputerRams.Add(dto);
            db.SaveChanges();
        }

        internal static void addNewVga(CumputerVga dto)
        {
           E_COM_WEBContext db=new E_COM_WEBContext();
            db.CumputerVgas.Add(dto);
            db.SaveChanges();   
        }

        internal static void saveAdminUser(AdminLogin dto)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.AdminLogins.Add(dto);
            db.SaveChanges();
        }

        internal static void saveAntivirusGard(AntivirusGard antivirus)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.AntivirusGards.Add(antivirus);
            db.SaveChanges();
        }
        internal static void saveCustomerAddress(CustomerAddressTb dto)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.CustomerAddressTbs.Add(dto);
            db.SaveChanges();
        }
        internal static void saveCustomerDataBase(CustomerDetail dto)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.CustomerDetails.Add(dto);
            db.SaveChanges();
        }

        internal static void saveDataToLaptopRoDesktopDetails(LaptopDesktopView dto)
        {
            E_COM_WEBContext db= new E_COM_WEBContext();
            db.LaptopDesktopViews.Add(dto);
            db.SaveChanges();
        }

        internal static void SaveNewHardDrive(CumputerHard dto)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.CumputerHards.Add(dto);
            db.SaveChanges();
        }

        internal static void saveNewProcessor(CumputerProcessor dto)
        {
            E_COM_WEBContext db = new E_COM_WEBContext();
            db.CumputerProcessors.Add(dto);
            db.SaveChanges();
        }

        internal static void saveNewProduct(ProductSpacification dto)
        {
            throw new NotImplementedException();
        }
    }
}
