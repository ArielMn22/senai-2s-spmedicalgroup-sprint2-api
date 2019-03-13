using Microsoft.EntityFrameworkCore;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void CadastrarUsuario(CadastrarUsuarioViewModel usuario) // O mesmo que cadastrar um administrador, tb serve para cadastrar um administrador.
        {
            Usuarios usuarioTemp;

            // Verifica se a imagem foi passada
            if (usuario.FotoPerfil != null && usuario.FotoPerfil.Length > 0)
            {
                // Defini o nome do arquivo
                var NomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(usuario.FotoPerfil.FileName);

                // Defini o caminho do arquivo
                var CaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\imgs", NomeArquivo);

                // Salva a imagem no caminho informado acima
                using (var StreamImagem = new FileStream(CaminhoArquivo, FileMode.Create))
                {
                    usuario.FotoPerfil.CopyTo(StreamImagem);
                }

                // Defini os valores do objeto Usuario
                usuarioTemp = new Usuarios
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    Fotoperfil = "/uploads/imgs/" + NomeArquivo,
                    IdTipoUsuario = usuario.IdTipoUsuario,
                    IdClinica = usuario.IdClinica
                };

            } else
            {
                usuarioTemp = new Usuarios
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    IdTipoUsuario = usuario.IdTipoUsuario,
                    IdClinica = usuario.IdClinica
                };

                
            }

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Usuarios.Add(usuarioTemp);
                ctx.SaveChanges();
            }

        }

        public void CadastrarMedico(MedicoViewModel medicoModel)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                CadastrarUsuario(medicoModel.UsuarioViewModel);

                // Pega o último registro cadastrado no banco de dados, por isso foi necessário salvar as alterações antes.
                Usuarios usuario = ctx.Usuarios.Last();

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
                CadastrarUsuario(pacienteModel.UsuarioViewModel);

                Usuarios usuario = ctx.Usuarios.Last(); // Retorna o último usuário cadastrado.

                // Atribui o Id de 'usuario' à propriedade IdUsuario do paciente.
                pacienteModel.Paciente.IdUsuario = usuario.Id;
                // Cadastra o paciente.
                ctx.Pacientes.Add(pacienteModel.Paciente);

                // Salva as alterações no BD.
                ctx.SaveChanges();
            }
        }

        public Usuarios RetornarEmUsuarios(CadastrarUsuarioViewModel usuarioViewModel)
        {
            // Defini os valores do objeto Usuario
            Usuarios usuarioTemp = new Usuarios
            {
                Nome = usuarioViewModel.Nome,
                Email = usuarioViewModel.Email,
                Senha = usuarioViewModel.Senha,
                Telefone = usuarioViewModel.Telefone,
                //FotoPerfil = "/uploads/imgs/" + NomeArquivo,
                IdTipoUsuario = usuarioViewModel.IdTipoUsuario,
                IdClinica = usuarioViewModel.IdClinica
            };

            return usuarioTemp;
        }

        public CadastrarUsuarioViewModel RetornarUsuarioViewModel(AdministradorStandaloneViewModel usuarioModel)
        {
            CadastrarUsuarioViewModel usuario = new CadastrarUsuarioViewModel()
            {
                Nome = usuarioModel.Nome,
                Email = usuarioModel.Email,
                Senha = usuarioModel.Senha,
                Telefone = usuarioModel.Telefone,
                FotoPerfil = usuarioModel.FotoPerfil,
                IdTipoUsuario = usuarioModel.IdTipoUsuario,
                IdClinica = usuarioModel.IdClinica
            };

            return usuario;
        }
    }
}
