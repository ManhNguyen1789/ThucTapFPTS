using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Areas.Admin
{
    //sử dụng thuộc tính để tuần tự hóa session ra nhị phân
    [Serializable]
    public class UserSession
    {
        public string  UserName { set; get; }
    }
}