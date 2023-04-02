using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.DAL
{
    public class User_DAL
    {
        private readonly M_SHOP_DBContext _db;



        public User_DAL(M_SHOP_DBContext db)
        {
            _db = db;
        }
        public void saveAdminUser(AdminLogin dto)
        {
            _db.AdminLogins.Add(dto);
            _db.SaveChanges();
        }
    }
}
