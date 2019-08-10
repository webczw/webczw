using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webczw.DBUtil;
using webczw.Models;

namespace webczw.DAL
{
    public class ActicleTypeService
    {
        public List<ActicleTypeModels> findList()
        {
            List<ActicleTypeModels> ActicleTypeModelsList = new List<ActicleTypeModels>();
            String sql = "select id,name,create_date,last_update_date,orders,description from ArticleTypes order by orders";
            SqlDataReader objReader = SqlHelper.getReader(sql);
            while (objReader.Read())
            {
                ActicleTypeModels acticleTypeModels = new ActicleTypeModels();
                acticleTypeModels.Id = Convert.ToInt32(objReader["id"]);
                acticleTypeModels.Name = Convert.ToString(objReader["name"]);
                acticleTypeModels.CreateDate = Convert.ToString(objReader["create_date"]);
                acticleTypeModels.LastUpdateDate = Convert.ToString(objReader["last_update_date"]);
                acticleTypeModels.Orders = Convert.ToInt32(objReader["orders"]);
                acticleTypeModels.Description = Convert.ToString(objReader["description"]);
                ActicleTypeModelsList.Add(acticleTypeModels);
            }
            return ActicleTypeModelsList;
        }

        public ActicleTypeModels findById(int id)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            String sql = "select id,name,create_date,last_update_date,orders,description from ArticleTypes where id=@id";
            SqlDataReader objReader = SqlHelper.getReader(sql, param);
            while (objReader.Read())
            {
                ActicleTypeModels acticleTypeModels = new ActicleTypeModels();
                acticleTypeModels.Id = Convert.ToInt32(objReader["id"]);
                acticleTypeModels.Name = Convert.ToString(objReader["name"]);
                acticleTypeModels.CreateDate = Convert.ToString(objReader["create_date"]);
                acticleTypeModels.LastUpdateDate = Convert.ToString(objReader["last_update_date"]);
                acticleTypeModels.Orders = Convert.ToInt32(objReader["orders"]);
                acticleTypeModels.Description = Convert.ToString(objReader["description"]);
                return acticleTypeModels;
            }
            return null;
        }
    }
}
