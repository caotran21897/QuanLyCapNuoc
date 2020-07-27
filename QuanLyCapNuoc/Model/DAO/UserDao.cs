using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{

    public class UserDao
    {
        CapThoatNuoc db = null;
        public UserDao()
        {
            db = new CapThoatNuoc();
        }
        public long Insert(NhanVien entity)
        {
            db.NhanViens.Add(entity);
            db.SaveChanges();
            return entity.nv_id;
        }
        public NhanVien GetByID(string username)
        {
            return db.NhanViens.SingleOrDefault(x => x.nv_tendangnhap == username);
        }
        public int Login(string username, string password)
        {
            var result = db.NhanViens.SingleOrDefault(x => x.nv_tendangnhap == username );
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.nv_matkhau == password)
                {
                    return 1;
                }
                else
                    return -2;
            }
        }
    }
}