using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WALLE.TestProject3.Model;

namespace WALLE.TestProject.IDAL
{
    public interface IUserInfoDal
    {
        List<UserInfo> GetEntityList();
        void LoadEntity(DataRow row, UserInfo userInfo);
        UserInfo GetEntityModel(int id);
        int DeleteEntityModel(int id);
        int InsertEntityModel(UserInfo userInfo);
        int UpdateEntityModel(UserInfo userInfo);
    }
}
