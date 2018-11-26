using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using WALLE.TestProject3.BLL;
using WALLE.TestProject3.Model;

namespace WALLE.TestProject3.WebApp
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            UserInfoService userInfoService = new UserInfoService();
            List<UserInfo> list = userInfoService.GetEntityList();
            StringBuilder sb = new StringBuilder();
            foreach(UserInfo userInfo in list)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ShowDetail.ashx?id={5}'>详细</a></td><td><a href='Delete.ashx?id={5}'>删除</a></td><td><a href='Edit.ashx?id={5}'>编辑</a></td></tr>", userInfo.ID, userInfo.UserName, userInfo.UserPass, userInfo.RegTime.ToShortTimeString(), userInfo.Email, userInfo.ID);
            }
            string filePath = context.Request.MapPath("UserInfoList.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("$tbody", sb.ToString());
            context.Response.Write(fileContent);
            
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