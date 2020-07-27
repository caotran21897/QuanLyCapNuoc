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
        public bool Login(string username, string password)
        {
            var result = db.NhanViens.Count(x => x.nv_tendangnhap == username && x.nv_matkhau == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}