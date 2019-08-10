using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models.Query
{
    [Serializable]
    public class ArticlesQueryModels
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int ArticleTypesId { get; set; }
    }
}
