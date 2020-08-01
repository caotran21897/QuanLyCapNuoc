using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserTypeDao
    {
        CapThoatNuoc db = null;
        public UserTypeDao()
        {
            db = new CapThoatNuoc();
        }
        public string Insert(LoaiKhachHang entity)
        {
                db.LoaiKhachHangs.Add(entity);
                db.SaveChanges();
                return entity.lkh_ma;

        }
        public List<LoaiKhachHang> List()
        {
            return db.LoaiKhachHangs.ToList();
        }
        public LoaiKhachHang GetByID(string code)
        {
            return db.LoaiKhachHangs.SingleOrDefault(x => x.lkh_ma == code);
        }
        public bool Update(LoaiKhachHang entity)
        {
            var type = db.LoaiKhachHangs.Find(entity.lkh_ma);
            type.lkh_ten = entity.lkh_ten;
            type.lkh_dongia = entity.lkh_dongia;
            db.SaveChanges();
            return true;

        }
        public bool Destroy(string code)
        {
            var check= db.KhachHangs.FirstOrDefault(x => x.lkh_ma == code);
            //check khóa ngoại
            if (check == null)
            {

            var type = db.LoaiKhachHangs.Find(code);
            db.LoaiKhachHangs.Remove(type);
            db.SaveChanges();
            return true;
            }
            return false;

        }
    }
}
