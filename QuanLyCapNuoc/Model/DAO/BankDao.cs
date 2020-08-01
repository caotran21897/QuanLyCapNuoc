using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BankDao
    {
        CapThoatNuoc db = null;
        public BankDao()
        {
            db = new CapThoatNuoc();
        }
        public int Insert(NganHang entity)
        {
            db.NganHangs.Add(entity);
            db.SaveChanges();
            return entity.nh_id;

        }
        public List<NganHang> List()
        {
            return db.NganHangs.ToList();
        }
        public NganHang GetByID(int code)
        {
            return db.NganHangs.SingleOrDefault(x => x.nh_id == code);
        }
        public bool Update(NganHang entity)
        {
            var type = db.NganHangs.Find(entity.nh_id);
            //type.nh_id = entity.nh_id;
            type.nh_ten = entity.nh_ten;
            type.nh_ma = entity.nh_ma;
            db.SaveChanges();
            return true;

        }
        public bool Destroy(int code)
        {
            var check = db.KhachHangs.FirstOrDefault(x => x.nh_id == code);
            //check khóa ngoại
            if (check == null)
            {

                var type = db.NganHangs.Find(code);
                db.NganHangs.Remove(type);
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
