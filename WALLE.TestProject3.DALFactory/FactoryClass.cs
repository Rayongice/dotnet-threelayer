using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WALLE.TestProject;
using WALLE.TestProject.IDAL;

namespace WALLE.TestProject3.DALFactory
{
    /// <summary>
    ///工厂模式（new） 封装了对象的创建;抽象工厂-->反射
    /// </summary>
    public class FactoryClass
    {
        public static IUserInfoDal CreateUserInfoDal()
        {
            return new DAL.UserInfoDal();
        }
    }
}
