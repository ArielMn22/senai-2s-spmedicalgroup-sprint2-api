using Microsoft.EntityFrameworkCore;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
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

        public List<Medicos> ListarMedicos()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Medicos.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }

        public MedicoViewModel RetornarMedicoViewModel(MedicoStandaloneViewModel medicoModel)
        {
            MedicoViewModel medico = new MedicoViewModel()
            {
                UsuarioViewModel = new CadastrarUsuarioViewModel()
                {
                    Nome = medicoModel.Nome,
                    Email = medicoModel.Email,
                    Senha = medicoModel.Senha,
                    Telefone = medicoModel.Telefone,
                    FotoPerfil = medicoModel.FotoPerfil,
                    IdTipoUsuario = medicoModel.IdTipoUsuario,
                    IdClinica = medicoModel.IdClinica
                },

                Medico = new Medicos()
                {
                    IdEspecialidade = medicoModel.IdEspecialidade,
                    Crm = medicoModel.Crm
                }
            };

            return medico;
        }
    }
}
