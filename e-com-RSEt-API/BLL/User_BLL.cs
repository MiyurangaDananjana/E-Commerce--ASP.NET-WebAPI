using e_com_RSEt_API.DAL;
using e_com_RSEt_API.Models;

namespace e_com_RSEt_API.BLL
{
    public class User_BLL
    {
        private readonly M_SHOP_DBContext _db;
        public User_BLL(M_SHOP_DBContext db)
        {
            _db = db;
        }

        public void addNewAdmin(AdminLogin dto)
        {
            User_DAL homeDAL = new User_DAL(_db);
            homeDAL.saveAdminUser(dto);
        }

    }
}
