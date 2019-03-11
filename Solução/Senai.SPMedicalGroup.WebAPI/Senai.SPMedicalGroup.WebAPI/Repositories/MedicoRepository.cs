using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public Medicos BuscarMedicoPorIdUsuario(int Idusuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Medicos.FirstOrDefault(x => x.IdUsuario == Idusuario);
            }
        }
    }
}
