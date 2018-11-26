using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Web;

namespace WALLE.TestProject3.WebApp._2018_11_26
{
    /// <summary>
    /// FileUpload 的摘要说明
    /// </summary>
    public class FileUpload : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile file = context.Request.Files["fileUp"];//接收文件数据
            if(file == null)
            {
                context.Response.Write("请选择文件");
            }
            else
            {
                //判断上传文件的类型.
                string fileName = Path.GetFileName(file.FileName);//获取文件名和扩展名
                string fileExt = Path.GetExtension(fileName);

                List<string> list = new List<string>();
                list.Add(".jpg");
                list.Add(".gif");
                list.Add(".png");
                list.Add(".jpeg");
                if (list.Contains(fileExt))
                {
                    string dir = "/ImagePath/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    //创建文件夹
                    Directory.CreateDirectory(Path.GetDirectoryName(context.Request.MapPath(dir)));
                    //整理文件名
                    string newFileName = Guid.NewGuid().ToString();
                    string fullDir = dir + newFileName + fileExt;//构建完整文件路径
                    //获取物理路径
                    //file.SaveAs(context.Request.MapPath(fullDir));
                    //根据上传的文件流创建image
                    using (Image image = Image.FromStream(file.InputStream))
                    {
                        using (Bitmap map = new Bitmap(image.Width, image.Height))
                        {
                            using (Graphics g = Graphics.FromImage(map))
                            {
                                //将图片画到画布上
                                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                                //在右下角添加水印
                                g.DrawString("walle loves ice", new Font("黑体", 14.0f, FontStyle.Bold), Brushes.Red, new PointF(image.Width - 100, image.Height - 30));
                                map.Save(fullDir);
                            }
                        }
                    }
                    
                        context.Response.Write("<html><head></head><img src='" + fullDir + "'/><body></body></html>");
                    //最后把上传成功的图片的路径存储到数据库中（下次用户登录去出即可）
                    //图片加载水印

                }
                else
                {
                    context.Response.Write("文件类型错误");
                }

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