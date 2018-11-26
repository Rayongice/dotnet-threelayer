using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WALLE.TestProject3.Model;

namespace WALLE.TestProject3.WebApp
{
    /// <summary>
    /// ProcessEdit 的摘要说明
    /// </summary>
    public class ProcessEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = context.Request.Form["UserName"];
            userInfo.UserPass = context.Request.Form["UserPass"];
            userInfo.RegTime = Convert.ToDateTime(context.Request.Form["RegTime"]);
            userInfo.Email = context.Request.Form["Email"];
            userInfo.ID = Convert.ToInt32(context.Request.Form["txtID"]);

            BLL.UserInfoService userInfoService = new BLL.UserInfoService();
            if(userInfoService.UpdateEntity(userInfo))
            {
                context.Response.Redirect("UserInfoList.ashx");
            }else
            {
                context.Response.Write("修改失败");
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