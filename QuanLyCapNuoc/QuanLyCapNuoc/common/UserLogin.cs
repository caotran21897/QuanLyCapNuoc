using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCapNuoc.common
{
    [Serializable]
    public class UserLogin
    {
        public long nv_ID { set; get; }
        public string nv_name { get; set; }
    }
}