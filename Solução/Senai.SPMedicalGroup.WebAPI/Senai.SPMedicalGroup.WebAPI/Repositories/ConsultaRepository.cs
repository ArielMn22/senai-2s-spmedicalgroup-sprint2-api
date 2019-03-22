using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
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

        public void Cadastrar(Consultas consulta)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consultas> ListarPorIdMedico(int idMedico)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdMedico == idMedico).ToList();
            }
        }

        public List<Consultas> ListarTodas()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.ToList();
            }
        }

        public List<Consultas> ListarPorIdPaciente(int idPaciente)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                // Retorna as consultas do paciente
                return ctx.Consultas.Where(x => x.IdPaciente == idPaciente).ToList();
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
    }
}
