using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.Models
{
    [Serializable]
    public class ActicleTypeModels : BaseModels
    {
        public String Name { get; set; }
        public int Orders { get; set; }
        public String Description { get; set; }
    }
}
