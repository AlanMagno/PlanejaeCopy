using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Planejae.DAL.Util;

namespace Planejae.DAL.Classes
{
    class ProjetoDAL
    {
        public void GetAll(DataTable datatable)
        {
            var exec = new ProcedureExecuter(datatable);
            exec.Execute("Sp_Projeto_Get");
        }
    }
}
