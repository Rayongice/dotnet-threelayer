using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WALLE.TestProject3.Model;
using WALLE.TestProject.IDAL;

namespace WALLE.TestProject3.BLL
{
    public class UserInfoService
    {
        //DAL.UserInfoDal UserInfoDal = new DAL.UserInfoDal();
        //IUserInfoDal UserInfoDal = new DAL.UserInfoDal();//变化点
        /// <summary>
        /// 业务层和数据层解耦了
        /// </summary>
        IUserInfoDal UserInfoDal = DALFactory.FactoryClass.CreateUserInfoDal();
        /// <summary>
        /// 返回列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetEntityList()
        {
            return UserInfoDal.GetEntityList();
        }
        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetModel(int id)
        {
            return UserInfoDal.GetEntityModel(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleEntity(int id)
        {
            return UserInfoDal.DeleteEntityModel(id) > 0;
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool InsertEntity(UserInfo userInfo)
        {
            return UserInfoDal.InsertEntityModel(userInfo) > 0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateEntity(UserInfo userInfo)
        {
            return UserInfoDal.UpdateEntityModel(userInfo) > 0;
        }
        

    }
}
