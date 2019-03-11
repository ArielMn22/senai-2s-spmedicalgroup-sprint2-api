using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void AtualizarDados(Clinica novaClinica, Clinica clinicaCadastrada)
        {
            //clinicaCadastrada.Localidade = (novaClinica.Localidade == null) ? clinicaCadastrada.Localidade : novaClinica.Localidade;
            clinicaCadastrada.Localidade = novaClinica.Localidade ?? clinicaCadastrada.Localidade;

            //clinicaCadastrada.HorarioFuncionamento = (novaClinica.HorarioFuncionamento == null) ? clinicaCadastrada.HorarioFuncionamento : novaClinica.HorarioFuncionamento;
            clinicaCadastrada.HorarioFuncionamento = novaClinica.HorarioFuncionamento ?? clinicaCadastrada.HorarioFuncionamento;

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Clinica.Update(clinicaCadastrada);
                ctx.SaveChanges();
            }
        }

        public Clinica BuscarClinicaPorId(int idClinica)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Clinica.Find(idClinica);
            }
        }

        public void CadastrarDados(Clinica clinica)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }
    }
}
