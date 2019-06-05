using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly IMongoCollection<ConsultaLocalizacao> _consultaLocalizacao;

        public ConsultaRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("spmedicalgroupAriel");
            _consultaLocalizacao = database.GetCollection<ConsultaLocalizacao>("consultas");
        }

        public void Atualizar(Consultas novaConsulta, Consultas consultaCadastrada)
        {
            // Validações para ver quais informações vão ser atualizadas.
            if (novaConsulta.Observacoes != null)
            {
                consultaCadastrada.Observacoes = novaConsulta.Observacoes;
            }

            if (novaConsulta.IdStatus != 0)
            {
                consultaCadastrada.IdStatus = novaConsulta.IdStatus;
            }

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Update(consultaCadastrada);
                ctx.SaveChanges();
            }
        }

        public Consultas BuscarPorId(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.Find(id);
            }
        }

        public int Cadastrar(Consultas consulta)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();

                return consulta.Id;
            }
        }

        public List<ConsultasViewModel> ListarPorIdMedico(int idMedico)
        {
            List<Consultas> consultas = new List<Consultas>();

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                consultas = ctx.Consultas.Where(x => x.IdMedico == idMedico)
                     //.Include(x => x.IdPaciente)
                     .Include(x => x.IdMedicoNavigation)
                     .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)
                     .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)
                     .Include(x => x.IdPacienteNavigation.IdUsuarioNavigation)
                     .Include(x => x.IdStatusNavigation)
                     .ToList();

                return TransformaEmConsultasViewModel(consultas);
            }
        }

        public List<ConsultasViewModel> ListarTodas()
        {
            List<Consultas> consultas = new List<Consultas>();

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                consultas = ctx.Consultas
                   .Include(x => x.IdMedicoNavigation)
                   .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)
                   .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)
                   .Include(x => x.IdPacienteNavigation.IdUsuarioNavigation)
                   .Include(x => x.IdStatusNavigation)
                   .ToList();
            }

            return TransformaEmConsultasViewModel(consultas);
        }

        public List<ConsultasViewModel> ListarPorIdPaciente(int idPaciente)
        {
            List<Consultas> consultas = new List<Consultas>();

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                // Retorna as consultas do paciente
                consultas = ctx.Consultas.Where(x => x.IdPaciente == idPaciente)
                    .Include(x => x.IdMedicoNavigation)
                    .Include(x => x.IdMedicoNavigation.IdUsuarioNavigation)
                    .Include(x => x.IdMedicoNavigation.IdEspecialidadeNavigation)
                    .Include(x => x.IdPacienteNavigation.IdUsuarioNavigation)
                    .Include(x => x.IdStatusNavigation)
                    .ToList();

                return TransformaEmConsultasViewModel(consultas);
            }
        }

        public bool ValidarConsulta(Consultas consulta)
        {
            List<Consultas> consultasMedico;

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                consultasMedico = new List<Consultas>();

                consultasMedico = ctx.Consultas.Where(x => x.IdMedico == consulta.IdMedico).ToList();
            }


            foreach (Consultas consultaItem in consultasMedico)
            {
                // Para ser válida, a data da consulta que está sendo cadastrada deve ser maior que 30 minutos da data da consulta cadastrada ou 30 minutos menor que a data da consulta cadastrada,
                // havendo assim um intervalo de 30 minutos entre cada consulta.
                if (consultaItem.DataConsulta > consulta.DataConsulta.AddMinutes(30) || consultaItem.DataConsulta < consulta.DataConsulta - TimeSpan.FromMinutes(30))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public List<ConsultasViewModel> TransformaEmConsultasViewModel(List<Consultas> consultas)
        {
            List<ConsultasViewModel> consultasViewModel = new List<ConsultasViewModel>();

            foreach (Consultas consulta in consultas)
            {
                ConsultasViewModel consultaViewModel = new ConsultasViewModel()
                {
                    Id = consulta.Id,
                    PacienteNome = consulta.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                    PacienteEmail = consulta.IdPacienteNavigation.IdUsuarioNavigation.Email,
                    MedicoNome = consulta.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                    MedicoEmail = consulta.IdMedicoNavigation.IdUsuarioNavigation.Email,
                    Especialidade = consulta.IdMedicoNavigation.IdEspecialidadeNavigation.Nome,
                    Descricao = consulta.Observacoes,
                    DataConsulta = consulta.DataConsulta.ToString(),
                    Preco = consulta.Preco.ToString(),
                    Status = consulta.IdStatusNavigation.Nome
                };

                consultasViewModel.Add(consultaViewModel);
            }
            return consultasViewModel;
        }

        public void CadastrarConsultaLocalidade(ConsultaLocalizacao consulta)
        {
            _consultaLocalizacao.InsertOne(consulta);
        }

        public List<ConsultaLocalidadeViewModel> ListarConsultasLocalidade()
        {
            List<ConsultaLocalizacao> consultas = _consultaLocalizacao.Find(async => true).ToList();

            List<ConsultaLocalidadeViewModel> consultasViewModel = new List<ConsultaLocalidadeViewModel>();

            foreach (ConsultaLocalizacao consultaLocalizacao in consultas)
            {
                ConsultasViewModel consultaViewModel = BuscarPorIdViewModel(consultaLocalizacao.IdConsulta);

                ConsultaLocalidadeViewModel consultaLocalidadeViewModel = new ConsultaLocalidadeViewModel()
                {
                    Id = consultaViewModel.Id,
                    PacienteNome = consultaViewModel.PacienteNome,
                    PacienteEmail = consultaViewModel.PacienteEmail,
                    MedicoNome = consultaViewModel.MedicoNome,
                    MedicoEmail = consultaViewModel.MedicoEmail,
                    Especialidade = consultaViewModel.Especialidade,
                    Descricao = consultaViewModel.Descricao,
                    DataConsulta = consultaViewModel.DataConsulta,
                    Preco = consultaViewModel.Preco,
                    Status = consultaViewModel.Status,
                    Latitude = consultaLocalizacao.Latitude,
                    Longitude = consultaLocalizacao.Longitude
                };

                consultasViewModel.Add(consultaLocalidadeViewModel);
            }

            return consultasViewModel;
        }

        public ConsultasViewModel BuscarPorIdViewModel(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                Consultas consultaProcurada = ctx.Consultas
                    .Include(x=>x.IdMedicoNavigation)
                    .Include(x=>x.IdMedicoNavigation.IdUsuarioNavigation)
                    .Include(x=>x.IdMedicoNavigation.IdEspecialidadeNavigation)
                    .Include(x=>x.IdPacienteNavigation)
                    .Include(x=>x.IdPacienteNavigation.IdUsuarioNavigation)
                    .Include(x=>x.IdStatusNavigation)
                    .FirstOrDefault(x => x.Id == id);

                return new ConsultasViewModel()
                {
                    Id = consultaProcurada.Id,
                    PacienteNome = consultaProcurada.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                    PacienteEmail = consultaProcurada.IdPacienteNavigation.IdUsuarioNavigation.Email,
                    MedicoNome = consultaProcurada.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                    MedicoEmail = consultaProcurada.IdMedicoNavigation.IdUsuarioNavigation.Email,
                    Especialidade = consultaProcurada.IdMedicoNavigation.IdEspecialidadeNavigation.Nome,
                    Descricao = consultaProcurada.Observacoes,
                    DataConsulta = consultaProcurada.DataConsulta.ToString(),
                    Preco = consultaProcurada.Preco.ToString(),
                    Status = consultaProcurada.IdStatusNavigation.Nome,
                };
            }
        }
    }
}
