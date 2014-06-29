using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Collections;
using System.Windows.Forms;

namespace Jiaowu
{
    public class JWManagerPJ
    {
        JWHttpCon httpcon = new JWHttpCon();
        JWLogin loginmethod = null;
        public enum LoginMode{UNITED_AUTHORITY,NORMAL}
        public JWManagerPJ()
        {
        }

        public bool setLoginMode(LoginMode lm)
        {
            if (loginmethod != null && loginmethod.islogged == true) loginmethod.logout();
            
            switch (lm)
            {
                case LoginMode.UNITED_AUTHORITY:
                    loginmethod = new JWLoginUnited(ref httpcon);
                    break;
                case LoginMode.NORMAL:
                    loginmethod = new JWLoginNormal(ref httpcon);
                    break;
                default:
                    return false;
            }
            return true;
        }
        bool logged
        {
            get { return loginmethod.islogged; }
        }

        public Image getCheckCode()
        {
            if (loginmethod == null) return null;

            return loginmethod.getCheckCode();
        }
        public bool login(string name,string pwd,string xcode,ref string html)
        {

            if (loginmethod == null) return false;

            return loginmethod.login(name, pwd, xcode, ref html);
        }
        public string getCoursePJHTML()
        {
            string html;
            HttpWebRequest req = httpcon.getGetReq(JWUrl.QUERYKC_URL);
            int count = 0;
            byte[] b = httpcon.getGetBytes(req,ref count);
            html = JWHttpCon.ByteToString(b, count, Encoding.UTF8);
            return html;
        }
        public CoursesPJ[] getCoursePJs(string html)
        {
            if (logged == false) return null;
            html = html.Substring(html.IndexOf("<input id=\"sfpj\""));
            Regex rex = new Regex("<td>[\\w\\W]*?<td>(.*?)</td>[\\w\\W]*?<td>[\\w\\W]*?<td>\\s*?<span[\\w\\W]*?<td>\\s*?<input type=\"button\" class=\"btn2\" idvalue=\"(.*)\" on.*value=\"(.*?)\"/>");
            MatchCollection col = rex.Matches(html);
            int count = 0;
            string temp = null;
            CoursesPJ[] cpj = new CoursesPJ[col.Count];

            foreach (Match m in col)
            {
                /*
                foreach (Group g in m.Groups)
                {
                    if (g.Value[0] == '{'&&g.Value[g.Length-1]=='}') 

                }
                 * */
                temp = m.Groups[2].Value.Substring(1, m.Groups[2].Value.Length - 2);

                string[] couples = temp.Split('\'');
                for (int i = 0; i < couples.Length; i++)  //c是键值对
                {
                    string c = couples[i];
                    switch (c)
                    {
                        case "SKJS":
                            cpj[count].skjs = couples[i + 2];
                            break;
                        case "KCDM":
                            cpj[count].kcdm = couples[i + 2];
                            break;
                        case "JXBH":
                            cpj[count].jxbh = couples[i + 2];
                            break;
                        case "SFPJ":
                            cpj[count].sfpj = couples[i + 2];
                            break;
                        default:
                            break;
                    }
                }
                //这两项应该是空的吧。谁知道呢
                cpj[count].gjz = "";
                cpj[count].gjz2 = "";

                cpj[count].name = m.Groups[1].Value;
                count++;
            }
            return cpj;
        }
        public TeacherPJ[] getTeacherInfo(ref CoursesPJ cpj)
        {
            string poststring = "skjs="+ HttpUtility.UrlEncode(cpj.skjs).ToUpper()+"&kcdm="+cpj.kcdm+"&jxbh="+cpj.jxbh+"&gjz="+cpj.gjz+"&gjz2="+cpj.gjz2+"&sfpj="+cpj.sfpj;
            poststring = poststring.Replace("%40", "@");
            byte[] postbytes = Encoding.UTF8.GetBytes(poststring);
            string html;
            HttpWebRequest req = httpcon.getPostReq(JWUrl.PJKC_URL);
            req.ContentLength = postbytes.Length;
            req.Referer = JWUrl.QUERYKC_URL;
            int count = 0;
            byte[] b = httpcon.getPostBytes(req,postbytes ,ref count);
            html = JWHttpCon.ByteToString(b, count, Encoding.UTF8);

            //查找所有的教师 td栏
            Regex re = new Regex("javascript:pjjs\\((.*?)\\)");
            MatchCollection col = re.Matches(html);
            count = 0;
            string[] result = new string[col.Count];
            TeacherPJ[] tpj = new TeacherPJ[col.Count];

            foreach (Match m in col)
            {
                foreach (Group g in m.Groups)
                {
                    if (g.Value[0] == '\'' && g.Value[g.Length - 1] == '\'')
                    {
                        result[count] = g.Value;
                        break;
                    }
                }
                string[] param = result[count].Split(',');
                tpj[count].zgh = param[0].Substring(1, param[0].Length - 2);
                tpj[count].sfpj=param[3].Substring(1, param[3].Length - 2);//
                tpj[count].kcdm=param[4].Substring(1, param[4].Length - 2);
                tpj[count].jxbh=param[5].Substring(1, param[5].Length - 2);
                tpj[count].yxfldm=param[1].Substring(1, param[1].Length - 2);
                tpj[count].fldm=param[2].Substring(1, param[2].Length - 2);

                tpj[count].gjz = cpj.gjz;//
                tpj[count].gjz2 = cpj.gjz2;//
                tpj[count].skjs = cpj.skjs;//
                tpj[count].coursepj = cpj;

                tpj[count].name = tpj[count].skjs.Split('@').ElementAt(1);//获取教师姓名

                tpj[count].hasUploaded = true;
                count++;
            }

            //获取每个教师的评价
            for(int i =0 ;i<tpj.Length;i++)
            {

                if (tpj[i].sfpj != "1") continue;
                poststring = "zgh=" + tpj[i].zgh +
                   "&sfpj=" + tpj[i].sfpj +
                   "&kcdm=" + tpj[i].kcdm +
                   "&jxbh=" + tpj[i].jxbh +
                   "&yxfldm=" + tpj[i].yxfldm +
                   "&fldm=" + tpj[i].fldm +
                   "&gjz=" + tpj[i].gjz +
                   "&gjz2=" + tpj[i].gjz2 +
                   "&skjs=" + HttpUtility.UrlEncode(tpj[i].skjs).ToUpper();
                poststring = poststring.Replace("%40", "@");
                postbytes = Encoding.UTF8.GetBytes(poststring);
                req = httpcon.getPostReq(JWUrl.PJTEACHER_URL);
                req.ContentLength = postbytes.Length;
                req.Referer = JWUrl.PJKC_URL;
                count = 0;
                b = httpcon.getPostBytes(req, postbytes, ref count);
                html = JWHttpCon.ByteToString(b, count, Encoding.UTF8);
                //获取评分
                Regex rex = new Regex("<td>\\d{4}</td>[\\w\\W]*?<option value=\"0(\\d)\" selected >");
                col = rex.Matches(html);
                count = 0;
                string evaluation = "";
                foreach (Match m in col)
                {
                    foreach (Group g in m.Groups)
                    {
                        int selected = 0;
                        if (int.TryParse(g.Value, out selected))
                        {
                            evaluation = evaluation + selected.ToString();
                        }
                    }
                }
                tpj[i].evaluation = evaluation;

                //获取评语
                rex = new Regex("<td colspan=\"3\"><span>评语:</span><span>(.*?)</span></td>");
                col = rex.Matches(html);
                tpj[i].py = col[0].Groups[1].Value;

                
            }
            //获取教师姓名
            
            cpj.teacherpj = tpj;
            return tpj;
        }
        public void saveTeacherPj(TeacherPJ tpj,string pj = "111112",string py = "")
        {
           
            string poststring = "zgh=" + tpj.zgh +
                "&sfpj=" + tpj.sfpj +
                "&kcdm=" + tpj.kcdm +
                "&jxbh=" + tpj.jxbh +
                "&yxfldm=" + tpj.yxfldm +
                "&fldm=" + tpj.fldm +
                "&gjz=" + tpj.gjz +
                "&gjz2=" + tpj.gjz2 +
                "&skjs=" + HttpUtility.UrlEncode(tpj.skjs).ToUpper();
            poststring = poststring.Replace("%40", "@");
            byte[] postbytes = Encoding.UTF8.GetBytes(poststring);
            string html;
            HttpWebRequest req = httpcon.getPostReq(JWUrl.PJTEACHER_URL);
            req.ContentLength = postbytes.Length;
            req.Referer = JWUrl.PJKC_URL;
            int count = 0;
            byte[] b = httpcon.getPostBytes(req, postbytes, ref count);
            html = JWHttpCon.ByteToString(b, count, Encoding.UTF8);

            string pjstr = "zgh=" + tpj.zgh +
                            "&jxbh=" + tpj.jxbh +
                            "&kcdm=" + tpj.kcdm +
                            "&fldm=" + tpj.fldm +
                            "&yxfldm=" + tpj.yxfldm +
                            "&skjs=" + HttpUtility.UrlEncode(tpj.skjs).ToUpper() +
                            "&gjz=" + tpj.gjz +
                            "&gjz2=" + tpj.gjz2 +
                            "&zhi=0" + pj[0] + "&ids=%7B%22zbdm%22%3A%220106%22%2C%22zbfz%22%3A%220"+pj[0]+"%22%7D" +
                            "&zhi=0" + pj[1] + "&ids=%7B%22zbdm%22%3A%220105%22%2C%22zbfz%22%3A%220"+pj[1]+"%22%7D" +
                            "&zhi=0" + pj[2] + "&ids=%7B%22zbdm%22%3A%220104%22%2C%22zbfz%22%3A%220"+pj[2]+"%22%7D" +
                            "&zhi=0" + pj[3] + "&ids=%7B%22zbdm%22%3A%220103%22%2C%22zbfz%22%3A%220"+pj[3]+"%22%7D" +
                            "&zhi=0" + pj[4] + "&ids=%7B%22zbdm%22%3A%220102%22%2C%22zbfz%22%3A%220"+pj[4]+"%22%7D" +
                            "&zhi=0" + pj[5] + "&ids=%7B%22zbdm%22%3A%220101%22%2C%22zbfz%22%3A%220"+pj[5]+"%22%7D" +
                            "&pyxx="+ py;
            
            pjstr = pjstr.Replace("%40", "@");
            postbytes = Encoding.UTF8.GetBytes(pjstr);
            req = httpcon.getPostReq(JWUrl.INSERTPJ_URL);
            req.ContentLength = pjstr.Length;
            req.Referer = JWUrl.PJTEACHER_URL;
            count = 0;
            try
            {
                b = httpcon.getPostBytes(req, postbytes, ref count);
                tpj.hasUploaded = false;
            }
            catch (Exception ex)
            {
            }
            html = JWHttpCon.ByteToString(b, count, Encoding.UTF8);
        }
        public void updatePj(CoursesPJ cpj)
        {

            string poststring = "zgh=&" + "sfpj=&kcdm=&jxbh=&yxfldm=&fldm=&gjz=&gjz2=&skjs=" + HttpUtility.UrlEncode(cpj.skjs).ToUpper();
            poststring = poststring.Replace("%40", "@");
            string posturl = JWUrl.SAVE_URL_PREFIX + cpj.jxbh;
            byte[] postbytes = Encoding.UTF8.GetBytes(poststring);
            string html;
            HttpWebRequest req = httpcon.getPostReq(posturl);
            req.ContentLength = postbytes.Length;
            req.Referer = JWUrl.PJKC_URL;
            int count = 0;
            try
            {
                byte[] b = httpcon.getPostBytes(req, postbytes, ref count);
                html = JWHttpCon.ByteToString(b, count, Encoding.UTF8);
            }
            catch (Exception ex)
            { 
            }

        }

             
    }
    public struct CoursesPJ
    {
        public string skjs;
        public string kcdm;
        public string jxbh;
        public string sfpj;

        public string gjz;
        public string gjz2;
        public TeacherPJ[] teacherpj;
        public string name;
        
    }
    public struct TeacherPJ
    {
            public string zgh;
            public string sfpj;//
            public string kcdm;//
            public string jxbh;//
            public string yxfldm;
            public string fldm;

            public string gjz;//
            public string gjz2;//
            public string skjs;//

            public string name;//extra info
            public string evaluation;
            public string py;
            public CoursesPJ coursepj;
            public bool hasUploaded;
    }

}
