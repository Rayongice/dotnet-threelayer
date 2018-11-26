using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WALLE.TestProject3.Model;

namespace WALLE.TestProject3.WebApp
{
    /// <summary>
    /// Edit 的摘要说明
    /// </summary>
    public class Edit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if(int.TryParse(context.Request.QueryString["id"], out id))
            {
                BLL.UserInfoService userInfoService = new BLL.UserInfoService();
                UserInfo userInfo = userInfoService.GetModel(id);
                string filePath = context.Request.MapPath("Edit.html");
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("$txtID", userInfo.ID.ToString()).Replace("$UserName", userInfo.UserName.ToString()).Replace("$UserPass", userInfo.UserPass.ToString()).Replace("$RegTime", userInfo.RegTime.ToShortDateString()).Replace("$Email", userInfo.Email.ToString());
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