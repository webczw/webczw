using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webczw.DAL;
using webczw.Models;

namespace webczw.BLL
{
    public class ActicleTypeManager
    {
        private ActicleTypeService acticleTypeService = new ActicleTypeService();

        private static ActicleTypeService staticActicleTypeService = new ActicleTypeService();

        public List<ActicleTypeModels> findList()
        {
            return acticleTypeService.findList();
        }

        public static List<ActicleTypeModels> list() {
            return staticActicleTypeService.findList();
        }

        public ActicleTypeModels findById(int id) {
            return acticleTypeService.findById(id);
        }
    }
}
