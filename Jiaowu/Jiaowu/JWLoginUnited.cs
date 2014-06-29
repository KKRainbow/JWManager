using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Jiaowu
{
    class JWLoginUnited:JWLogin
    {
        public static string CODE_URL = "https://ecampus.buaa.edu.cn/cas/security/initDigitPicture.do?Rgb=255|255|255&width=60&height=24";
        public static string LOGINDEX_URL
        {
            get
            {
                return "https://ecampus.buaa.edu.cn/cas/login?service=http%3A%2F%2F"+JWUrl.HOST.Substring(7,15)+"%3A7001%2Fieas2%2Fwelcome";
            }
        }
        public static string LOGIN_URL
        {
            get
            {
                return "https://ecampus.buaa.edu.cn/cas/login?service=http%3A%2F%2F" + JWUrl.HOST.Substring(7,15) + "%3A7001%2Fieas2%2Fwelcome";
            }
        }
        private bool logged = false;
        LoginHeader loginheader = new LoginHeader();
        JWHttpCon httpcon = null;
        public JWLoginUnited(ref JWHttpCon mhttpcon)
        {
            ServicePointManager.ServerCertificateValidationCallback +=delegate(object sender,X509Certificate certificate,
                        X509Chain chain,
                 SslPolicyErrors sslPolicyErrors)
            {
                   return true;
            };
            httpcon = mhttpcon;
            init();
        }
        public bool islogged
        {
            get
            {
                return logged;
            }
        }
        public bool login( string name, string pwd, string xcode, ref string html)
        {
            Type tp = typeof(LoginHeader);
            FieldInfo[] fi = tp.GetFields();
            loginheader.username = name;
            loginheader.password = pwd;
            loginheader.j_digitPicture = xcode;
            string post = "";
            foreach (FieldInfo info in fi) 
            {
                post = post + "&" + info.Name + "=" + info.GetValue(loginheader);
            }
            post = post.Remove(0,1);

            

            HttpWebRequest req = httpcon.getPostReq(LOGIN_URL);
            req.Referer = LOGINDEX_URL;

            byte[] test = Encoding.UTF8.GetBytes(post);
            int count = 0;
            byte[] result = httpcon.getPostBytes(req, test, ref count);
            html = JWHttpCon.ByteToString(result, count, Encoding.GetEncoding("GB2312"));
            if (html.IndexOf("北京航空航天大学-统一认证中心") >= 0) return false;
            HttpWebResponse res = httpcon.getLastResponse;
            
            string ticket = res.ResponseUri.AbsoluteUri;
            
            req = httpcon.getGetReq(ticket);
            count = 0;
            result = httpcon.getGetBytes(req, ref count);
            html = JWHttpCon.ByteToString(result, count, Encoding.UTF8);
            logged = true;
            return true;
        }
        public Image getCheckCode( )
        {
            try
            {


                HttpWebRequest req = httpcon.getGetReq(CODE_URL);
                req.Accept = "image/png,image/*;q=0.8,*/*;q=0.5";
                req.Headers["Accept-Language"] = "zh,en-us;q=0.7,en;q=0.3";
                
                req.Referer = LOGINDEX_URL;
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
        public void init()
        {
            HttpWebRequest req = httpcon.getGetReq(LOGINDEX_URL);
            string html;
            int count = 0;
            byte[] b = httpcon.getGetBytes(req, ref count);
            html = JWHttpCon.ByteToString(b, count, Encoding.GetEncoding("GB2312"));

            Regex re = new Regex("<input type=\"hidden\" name=\"lt\" value=\"(.*?)\" />");
            MatchCollection col = re.Matches(html);
            foreach (Match m in col)
            {
                foreach (Group g in m.Groups)
                {
                    if (g.Value[0] != '<' && g.Value[g.Length - 1] != '>')
                        loginheader.lt = g.Value.Substring(0, g.Value.Length);
                }
            }


            loginheader._eventId = "submit";
            loginheader.changePassWord = "";
            loginheader.loginType = "0";
        }
        public void logout()
        {
            httpcon = new JWHttpCon();
        }
        class LoginHeader
        {
            public string lt;
            public string _eventId;
            public string changePassWord;
            public string loginType;
            public string username;
            public string password;
            public string j_digitPicture;
            
        }
    }
}
