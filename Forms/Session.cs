using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.Forms
{
    public static class Session
    {
        public static string FullName { get; set; }
        public static string Username { get; set; }
        public static int Role { get; set; } // 0: Nhân viên, 1: Quản lý
    }
}
