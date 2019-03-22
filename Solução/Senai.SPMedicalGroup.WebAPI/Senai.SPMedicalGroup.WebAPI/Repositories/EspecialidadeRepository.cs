using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        public void Cadastrar(Especialidades especialidade)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Especialidades.Add(especialidade);
            }
        }

        public List<Especialidades> ListarTodas()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Especialidades.ToList();
            }
        }
    }
}
