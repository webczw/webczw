using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models
{
    [Serializable]
    public class ArticlesModels
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public String Author { get; set; }
        public int ArticleTypesId { get; set; }
        public String CreateDate { get; set; }
        public String Tags { get; set; }
        public int Ctr { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public String LastUpdateDate { get; set; }
    }
}
