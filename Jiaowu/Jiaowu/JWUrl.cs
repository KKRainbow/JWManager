using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiaowu
{
    static class JWUrl
    {
        public const string Host1 = "http://202.112.132.144:7001";
        public const string Host2 = "http://202.112.132.147:7001";
        public static string HOST = "http://202.112.132.144:7001";

        public static void changeHost(string host)
        {
            HOST = host;
        }

        public static string mCODE_URL = "/ieas2/captchaImage?id=5951";
        public static string mLOGINDEX_URL = "/ieas2/loginIndex";
        public static string mCHECKCODE_URL = "/ieas2/checkCode";
        public static string mLOGIN_URL = "/ieas2/login";
        public static string mQUERYKC_URL = "/ieas2/xspj/queryPjkc";
        public static string mPJKC_URL = "/ieas2/xspj/pjkc";
        public static string mPJTEACHER_URL = "/ieas2/xspj/pjTeacher";
        public static string mINSERTPJ_URL = "/ieas2/xspj/insertPj";
        public static string mSAVE_URL_PREFIX = "/ieas2/xspj/updateTj?rwh=";

        public static string CODE_URL
        {get { return HOST+mCODE_URL; }}
        public static string LOGINDEX_URL
        {get { return HOST+mCODE_URL; }}
        public static string CHECKCODE_URL 
        { get { return HOST + mCHECKCODE_URL; } }
        public static string LOGIN_URL 
        { get { return HOST + mLOGIN_URL; } }
        public static string QUERYKC_URL 
        { get { return HOST + mQUERYKC_URL; } }
        public static string PJKC_URL 
        { get { return HOST + mPJKC_URL; } }
        public static string PJTEACHER_URL 
        { get { return HOST + mPJTEACHER_URL; } }
        public static string INSERTPJ_URL 
        { get { return HOST + mINSERTPJ_URL; } }
        public static string SAVE_URL_PREFIX
        { get { return HOST + mSAVE_URL_PREFIX; } } 
    }
}
