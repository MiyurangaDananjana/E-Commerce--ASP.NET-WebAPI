using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.BLL
{
    public class Customer_BLL
    {
        private readonly M_SHOP_DBContext _db;
        public Customer_BLL(M_SHOP_DBContext db)
        {
            _db = db;
        }
        public void saveCustomer(CustomerDetail dto)
        {
            Customer_DAL homeDAL = new Customer_DAL(_db);
            homeDAL.saveCustomerDataBase(dto);
        }
        public void saveCustomerAddress(CustomerAddressTb dto)
        {
            Customer_DAL homeDAL = new Customer_DAL(_db);
            homeDAL.saveCustomerAddress(dto);
        }

    }
}
