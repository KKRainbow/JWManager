using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Jiaowu
{
    interface JWLogin
    {
        bool login(string name, string pwd, string xcode, ref string html);
        Image getCheckCode();
        void logout();
        bool islogged
        {
            get;
        }
    }
}
