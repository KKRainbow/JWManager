using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Jiaowu
{
    class JWHttpCon
    {
        private CookieContainer cookie = new CookieContainer();
        HttpWebResponse lastresponse = null;
        public HttpWebResponse getLastResponse
        {
            get{return lastresponse;}
        }
        private HttpWebRequest getReq(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            req.KeepAlive = true;
            req.Timeout = 90000;
            req.CookieContainer = cookie;
            req.Headers["Accept-Encoding"] = " gzip, deflate";
            req.Headers["Cache-Control"] = " no-cache";
            req.Headers["Accept-Language"] = " zh-CN";
            req.ContentType = "application/x-www-form-urlencoded";
            return req;
        }
        public HttpWebRequest getGetReq(string url)
        {
            HttpWebRequest req = getReq(url);
            req.Method = "GET";
            req.Accept = "text/html, application/xhtml+xml, */*";
            return req;
        }
        public HttpWebRequest getImgReq(string url)
        {
            HttpWebRequest req = getReq(url);
            req.Method = "GET";
            req.Accept = "image/png, image/svg+xml, image/*;q=0.8, */*;q=0.5";
            return req;
        }
        public HttpWebRequest getJsonReq(string url,int ContentLength)
        {
            HttpWebRequest req = getReq(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            req.Accept = "application/json, text/javascript, */*; q=0.01";
            req.ContentLength = ContentLength;
            req.ProtocolVersion = new Version("1.0");
            req.Headers.Add("X-Requested-With", "XMLHttpRequest");
//            req.Referer = "http://202.112.132.144:7001/ieas2/loginIndex";
            return req;
        }
        public HttpWebRequest getPostReq(string url)
        {
            HttpWebRequest req = getReq(url);
            req.Method = "POST";
            req.Accept = "text/html, application/xhtml+xml, */*";
//            req.Referer = "http://202.112.132.144:7001/ieas2/loginIndex";
            req.ContentType = "application/x-www-form-urlencoded";
            return req;
        }
        public byte[] getGetBytes(HttpWebRequest req,ref int length)
        {
            lastresponse = (HttpWebResponse)req.GetResponse();
            Stream sm = lastresponse.GetResponseStream();
            int i = 0, count = 0;
            byte[] k = new byte[50000];
            while ((i = sm.ReadByte()) != -1)
            {
                k[count++] = (byte)i;
            }
            length = count;
            return k;
        }
        public byte[] getPostBytes(HttpWebRequest req, byte[] postBytes, ref int length)
        {
            Stream requestStream = req.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            
            lastresponse = (HttpWebResponse)req.GetResponse();
            Stream sm = lastresponse.GetResponseStream();
            int i = 0, count = 0;
            byte[] k = new byte[50000];
            while ((i = sm.ReadByte()) != -1)
            {
                k[count++] = (byte)i;
            }
            length = count;
            
            return k;
        }
        public static string ByteToString(byte[] bytes, int length, Encoding encoding)
        {
            return new StreamReader(new MemoryStream(bytes, 0, length), encoding).ReadToEnd();
        }

    }
}
