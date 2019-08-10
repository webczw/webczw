using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models
{
    [Serializable]
    public class ArticlesModels : BaseModels
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public String Author { get; set; }
        public int ArticleTypesId { get; set; }
        public String Tags { get; set; }
        public int Ctr { get; set; }
    }
}
