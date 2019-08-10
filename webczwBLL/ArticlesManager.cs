using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webczw.DAL;
using webczw.Models;
using webczw.Models.Query;

namespace webczw.BLL
{
    public class ArticlesManager
    {
        private ArticlesService articlesService = new ArticlesService();
        public PageResultModels<ArticlesModels> findListByPage(ArticlesQueryModels articlesQueryModels)
        {
            List<ArticlesModels> list = articlesService.findListByPage(articlesQueryModels);
            int totalNumber = articlesService.findListByPageCount(articlesQueryModels);
            int pageSize = articlesQueryModels.PageSize;
            int totalPage = totalNumber / pageSize;
            if (totalNumber % pageSize != 0)
            {
                totalPage++;
            }

            PageResultModels<ArticlesModels> pageResultModels = new PageResultModels<ArticlesModels>();
            pageResultModels.PageSize = pageSize;
            pageResultModels.CurrentPage = articlesQueryModels.CurrentPage;
            pageResultModels.TotalNumber = totalNumber;
            pageResultModels.TotalPage = totalPage;
            pageResultModels.List = list;
            setPageInfo(pageResultModels, articlesQueryModels);
            return pageResultModels;
        }

        public void setPageInfo(PageResultModels<ArticlesModels> pageResultModels, ArticlesQueryModels articlesQueryModels)
        {
            //用户当前请求页码
            int currentPage = pageResultModels.CurrentPage;
            //数据库数据总页数
            int totalPage = pageResultModels.TotalPage;
            //总分页数量
            const int totalPageSize = 11;
            int center = (totalPageSize / 2) + 1;
            int size = totalPageSize;
            int i = 0;


            if (currentPage > center)
            {
                int deviation = currentPage - center;
                i = deviation;
                size = totalPageSize + deviation;
            }

            if (totalPage < totalPageSize)
            {
                size = totalPage;
            }
            else if ((i + totalPageSize) > totalPage)
            {
                i = totalPage - totalPageSize;
                size = i + totalPageSize;
            }
            List<PageModels> numberList = new List<PageModels>();
            for (; i < size; i++)
            {
                PageModels pageModels = new PageModels();
                int page = i + 1;
                pageModels.Number = page;
               
                    pageModels.Uri = uri(page, articlesQueryModels);
              
                
                numberList.Add(pageModels);
            }
            pageResultModels.NumberList = numberList;
            pageResultModels.Previous = uri(currentPage == 1 ? 1 : currentPage - 1, articlesQueryModels);
            pageResultModels.Next = uri(currentPage == totalPage ? totalPage : currentPage + 1, articlesQueryModels);
            pageResultModels.First = uri(1, articlesQueryModels);
            pageResultModels.Last = uri(totalPage, articlesQueryModels);
        }

        public String uri(int page, ArticlesQueryModels articlesQueryModels)
        {
            if (articlesQueryModels.ArticleTypesId == 0)
            {
                return page.ToString();
            }
            else
            {
                return page.ToString() + "/" + articlesQueryModels.ArticleTypesId;
            }
        }

        public ArticlesModels findById(int id)
        {
            return articlesService.findById(id);
        }
    }
}
