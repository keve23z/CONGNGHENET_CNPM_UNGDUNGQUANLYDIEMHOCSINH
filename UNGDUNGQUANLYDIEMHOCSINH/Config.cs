using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    public class Config
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        internal const string HOCSINH_TABLE = "HocSinh";

        internal const string PHUHUYNH_TABLE = "PhuHuynh";

        internal const string DIEM_TABLE = "Diem";

        internal const string DanhGiaHanhKiem_TABLE = "DanhGiaHanhKiem";

        internal const string DanhGiaHocLuc_TABLE = "DanhGiaHocLuc";

        internal const string LOP_TABLE = "Lop";

        internal const string KHOI_TABLE = "Khoi";

        internal const string NIENKHOA_TABLE = "NienKhoa";

        internal const string PHANCONG_TABLE = "PhanCong";

        internal const string LOGIN_TABLE = "Login";
    }
}
