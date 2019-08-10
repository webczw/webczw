using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models
{
    public class PageResultModels<T>
    {
        public List<T> List { get; set; }
        public int TotalPage { get; set; }
        public int TotalNumber { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public String First { get; set; }
        public String Last { get; set; }
        public String Previous { get; set; }
        public String Next { get; set; }
        public List<PageModels> NumberList { get; set; }

    }
}
