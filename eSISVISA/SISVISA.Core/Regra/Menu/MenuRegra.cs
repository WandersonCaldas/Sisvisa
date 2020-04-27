using SISVISA.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISVISA.Core.Regra
{
    public class MenuRegra
    {
        private MenuRepository _repository = new MenuRepository();
        public List<SISVISA.Core.Models.Menu> Listar()
        {
            return _repository.Listar();
        }
    }
}
