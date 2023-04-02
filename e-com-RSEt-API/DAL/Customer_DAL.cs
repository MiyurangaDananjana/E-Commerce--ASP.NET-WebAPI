using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.DAL
{
    public class Customer_DAL
    {
        private readonly M_SHOP_DBContext _db;



        public Customer_DAL(M_SHOP_DBContext db)
        {
            _db = db;
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

    }
}
