using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using System.IO;

namespace Jiaowu
{
    class JWLoginNormal : JWLogin
    {
        private bool logged = false;
        JWHttpCon httpcon = null;
        public bool islogged
        {
            get
            {
                return logged;
            }
        }
        public JWLoginNormal(ref JWHttpCon mhttpcon)
        {
            httpcon = mhttpcon;
        }
        public bool login(string name, string pwd, string xcode, ref string html)
        {
            string code = "code=" + xcode;
            HttpWebRequest req = httpcon.getJsonReq(JWUrl.CHECKCODE_URL, code.Length);
            req.Referer = JWUrl.LOGINDEX_URL;
            int count = 0;
            byte[] result = httpcon.getPostBytes(req, Encoding.UTF8.GetBytes(code), ref count);

            if (JWHttpCon.ByteToString(result, count, Encoding.UTF8) != "true")
            {
                html = "code";
                return false;
            }

            req = httpcon.getPostReq(JWUrl.LOGIN_URL);
            req.Referer = JWUrl.LOGINDEX_URL;

            byte[] test = Encoding.UTF8.GetBytes("usercode=" + name + "&password=" + pwd + "&code=" + xcode + "&usertype=xj");
            result = httpcon.getPostBytes(req, test, ref count);

            html = JWHttpCon.ByteToString(result, count, Encoding.UTF8);
            if (html.IndexOf("用户不存在或密码错误") >= 0)
            {
                logged = false;
                html = "user";
            }
            logged = true;
            return true;
        }
        public Image getCheckCode()
        {
            try
            {
                HttpWebRequest req = httpcon.getGetReq(JWUrl.CODE_URL);
                req.Referer = JWUrl.LOGINDEX_URL;
                int count = 0;
                byte[] k = httpcon.getGetBytes(req, ref count);
                MemoryStream a = new MemoryStream(k, 0, count);
                return Image.FromStream(a);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void logout()
        {
            httpcon = new JWHttpCon();
        }
    }
}
