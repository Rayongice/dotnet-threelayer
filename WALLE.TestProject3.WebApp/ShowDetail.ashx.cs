using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WALLE.TestProject3.Model;

namespace WALLE.TestProject3.WebApp
{
    /// <summary>
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if(int.TryParse(context.Request.QueryString["id"], out id))
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                UserInfo userInfo = userInfoService.GetModel(id);
                string filePath = context.Request.MapPath("ShowDetail.html");
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("$name", userInfo.UserName.ToString()).Replace("$pwd", userInfo.UserPass.ToString());
                context.Response.Write(fileContent);                
            }

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