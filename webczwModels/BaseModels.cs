using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models
{
    [Serializable]
    public class BaseModels
    {
        public int Id { get; set; }
        public String CreateDate { get; set; }
        public String LastUpdateDate { get; set; }
    }
}
