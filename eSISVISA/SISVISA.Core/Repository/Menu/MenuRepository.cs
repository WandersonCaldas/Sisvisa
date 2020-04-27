using SISVISA.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SISVISA.Core.Repository
{
    public class MenuRepository
    {
        private SqlConnection _db = Conexao.GetInstance().GetConnection;

        public List<Menu> Listar()
        {
            return _db.Query<Menu>("SELECT * FROM tbl_menu WHERE cod_ativo = 1 ORDER BY nr_pai ASC, txt_nome ASC, nr_ordem ASC").ToList();
        }
    }
}
