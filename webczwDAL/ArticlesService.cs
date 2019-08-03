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
    public class ArticlesService
    {

        public List<ArticlesModels> findListByPage(ArticlesModels articlesModels)
        {
            List<ArticlesModels> articlesModelsList = new List<ArticlesModels>();
            String sql = "select top {0} t.id,t.title,t.create_date,t.article_types_id,t.ctr   from Articles t where t.article_types_id=@ArticleTypesId and t.Id not in (select top {1} t1.Id from Articles t1 where t1.article_types_id=@ArticleTypesId order by t1.create_date desc) order by t.create_date desc";
           
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ArticleTypesId",articlesModels.ArticleTypesId)
            };
            if (articlesModels.ArticleTypesId == 0) {
                sql = "select top {0} t.id,t.title,t.create_date,t.article_types_id,t.ctr   from Articles t where t.Id not in (select top {1} t1.Id from Articles t1 order by t1.create_date desc) order by t.create_date desc";
                
            }
            sql = String.Format(sql, articlesModels.PageSize, (articlesModels.CurrentPage * articlesModels.PageSize));
            SqlDataReader objReader = SqlHelper.getReader(sql, param);
            while (objReader.Read())
            {
                ArticlesModels articles = new ArticlesModels();
                articles.Id = Convert.ToInt32(objReader["id"]);
                articles.Title = Convert.ToString(objReader["title"]);
                articles.CreateDate = Convert.ToString(objReader["create_date"]);
                articles.Ctr = Convert.ToInt32(objReader["ctr"]);
                articlesModelsList.Add(articles);
            }
            return articlesModelsList;
        }

        public ArticlesModels findById(int id) {
            String sql = "select t.id,t.title,t.content,t.author,t.tags,t.last_update_date,t.create_date,t.article_types_id,t.ctr   from Articles t where t.id=@Id ";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id",id)
            };

            SqlDataReader objReader = SqlHelper.getReader(sql, param);
           
                while (objReader.Read())
                {
                    ArticlesModels articles = new ArticlesModels();
                    articles.Id = Convert.ToInt32(objReader["id"]);
                    articles.Title = Convert.ToString(objReader["title"]);
                    articles.CreateDate = Convert.ToString(objReader["create_date"]);
                    articles.Ctr = Convert.ToInt32(objReader["ctr"]);
                    articles.Content = Convert.ToString(objReader["content"]);
                    articles.Author = Convert.ToString(objReader["author"]);
                    articles.Tags = Convert.ToString(objReader["tags"]);
                    articles.LastUpdateDate = Convert.ToString(objReader["last_update_date"]);
                    return articles;
                }
           
                return null;
            
            
        }
    }
}
