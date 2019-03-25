using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        public List<TipoStatus> ListarTodos()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.TipoStatus.ToList();
            }
        }
    }
}
