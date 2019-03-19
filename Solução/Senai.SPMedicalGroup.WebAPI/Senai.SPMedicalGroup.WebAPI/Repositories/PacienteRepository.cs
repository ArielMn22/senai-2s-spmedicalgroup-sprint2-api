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
    public class PacienteRepository : IPacienteRepository
    {
        public Pacientes BuscarPacientePorIdUsuario(int idUsuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Pacientes.FirstOrDefault(x => x.IdUsuario == idUsuario);
            }
        }

        public List<Pacientes> ListarPacientes()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Pacientes.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }

        public PacienteViewModel RetornarPacienteViewModel(PacienteStandaloneViewModel pacienteModel)
        {
            PacienteViewModel paciente = new PacienteViewModel()
            {
                UsuarioViewModel = new CadastrarUsuarioViewModel()
                {
                    Nome = pacienteModel.Nome,
                    Email = pacienteModel.Email,
                    Senha = pacienteModel.Senha,
                    Telefone = pacienteModel.Telefone,
                    FotoPerfil = pacienteModel.FotoPerfil,
                    IdTipoUsuario = pacienteModel.IdTipoUsuario,
                    IdClinica = pacienteModel.IdClinica
                },

                Paciente = new Pacientes()
                {
                    IdUsuario = pacienteModel.IdUsuario,
                    Rg = pacienteModel.Rg,
                    Cpf = pacienteModel.Cpf,
                    DataNascimento = pacienteModel.DataNascimento,
                    Endereco = pacienteModel.Endereco
                }
            };

            return paciente;
        }
    }
}
