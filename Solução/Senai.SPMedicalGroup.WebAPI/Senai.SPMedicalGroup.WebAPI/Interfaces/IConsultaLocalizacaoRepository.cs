using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IConsultaLocalizacaoRepository
    {
        /// <summary>
        /// Listar as localizações das consultas.
        /// </summary>
        /// <returns>A localização da consulta, junto com os dados referentes à ela.</returns>
        List<ConsultaLocalidadeViewModel> Listar();

        /// <summary>
        /// Cadastrar a localização de uma consulta. Obs: Junto com seu id.
        /// </summary>
        /// <param name="consulta">ConsultaLocalização Object.</param>
        void Cadastrar(ConsultaLocalizacao consulta);
    }
}
