using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetRandomCaching
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           
            DirInfoCacher infoCacher = new DirInfoCacher();

            string randomEl = infoCacher.GetRandom();

            context.Response.Write(randomEl);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}