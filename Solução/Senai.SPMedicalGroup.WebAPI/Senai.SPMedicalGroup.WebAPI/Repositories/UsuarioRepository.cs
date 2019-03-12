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
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                // terá tanto os usuários, quanto os tipos deles.
                // Retorna um usuário que coincida com o e-mail e senha.
                return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            }
        }

        public void CadastrarAdministrador(Usuarios usuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void CadastrarMedico(MedicoViewModel medicoModel)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Usuarios.Add(medicoModel.Usuario);

                // Salva as alterações no BD.
                ctx.SaveChanges();

                // Pega o último registro cadastrado no banco de dados, por isso foi necessário salvar as alterações antes.
                Usuarios usuario  = ctx.Usuarios.Last();

                // Atribui o usuario Id à proprieadade usuarioId do Medico.
                medicoModel.Medico.IdUsuario = usuario.Id;

                // Cadastra o médico.
                ctx.Medicos.Add(medicoModel.Medico);

                // Salva as alterações no banco;
                ctx.SaveChanges();
            }
        }

        public void CadastrarPaciente(PacienteViewModel pacienteModel)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                // Cadastra o usuário.
                ctx.Usuarios.Add(pacienteModel.Usuario);
                
                // Salva as alterações no BD.
                ctx.SaveChanges();

                Usuarios usuario = ctx.Usuarios.Last(); // Retorna o último usuário cadastrado.

                // Atribui o Id de 'usuario' à propriedade IdUsuario do paciente.
                pacienteModel.Paciente.IdUsuario = usuario.Id;
                // Cadastra o paciente.
                ctx.Pacientes.Add(pacienteModel.Paciente);

                // Salva as alterações no BD.
                ctx.SaveChanges();
            }
        }
    }
}
