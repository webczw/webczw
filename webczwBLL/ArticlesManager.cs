using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webczw.DAL;
using webczw.Models;

namespace webczw.BLL
{
    public class ArticlesManager
    {
        private ArticlesService articlesService = new ArticlesService();
        public PageResultModels<ArticlesModels> findListByPage(ArticlesModels articlesModels)
        {
            List<ArticlesModels> list = articlesService.findListByPage(articlesModels);
            PageResultModels<ArticlesModels> pageResultModels = new PageResultModels<ArticlesModels>();
            pageResultModels.PageSize = articlesModels.PageSize;
            pageResultModels.CurrentPage = articlesModels.CurrentPage;
            pageResultModels.List = list;
            return pageResultModels;
        }

        public ArticlesModels findById(int id)
        {
            return articlesService.findById(id);
        }
    }
}
