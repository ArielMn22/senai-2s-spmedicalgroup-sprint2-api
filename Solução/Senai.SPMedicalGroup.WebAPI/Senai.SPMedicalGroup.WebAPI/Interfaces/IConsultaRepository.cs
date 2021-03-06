﻿using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as consultas;
        /// </summary>
        /// <returns>Retorna uma lista de consultas.</returns>
        //List<ConsultasViewModel> ListarTodas();
        List<ConsultaLocalidadeViewModel> ListarTodas();

        /// <summary>
        /// Atualiza uma consulta com as informções passadas.
        /// </summary>
        /// <param name="consulta">Dados de uma consulta.</param>
        void Atualizar(Consultas novaConsulta, Consultas consultaCadastrada);

        /// <summary>
        /// Cadastra uma consulta.
        /// </summary>
        /// <param name="consulta">Um objeto do tipo Consultas.</param>
        int Cadastrar(Consultas consulta);

        /// <summary>
        /// Lista as consultas que possuem o Id do médico passado por parâmetro;
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Uma lista de consultas.</returns>
        //List<ConsultasViewModel> ListarPorIdMedico(int idMedico);
        List<ConsultaLocalidadeViewModel> ListarPorIdMedico(int idMedico);

        /// <summary>
        /// Lista as consultas que possitem o id do paciente passado por parâmetro.
        /// </summary>
        /// <param name="id">Id do paciente.</param>
        /// <returns>Uma lista de consultas.</returns>
        //List<ConsultasViewModel> ListarPorIdPaciente(int idPaciente);
        List<ConsultaLocalidadeViewModel> ListarPorIdPaciente(int idPaciente);

        /// <summary>
        /// Busca um usuário pelo ID.
        /// </summary>
        /// <param name="id">Id da consulta.</param>
        /// <returns>uma Consulta.</returns>
        Consultas BuscarPorId(int id);

        /// <summary>
        /// Busca uma consultaViewModel pelo Id Consultas.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ConsultasViewModel BuscarPorIdViewModel(int id);

        /// <summary>
        /// Valida se a consulta pode ser cadastrada ou não;
        /// </summary>
        /// <param name="consulta">Objeto Consultas</param>
        /// <returns>Se true, pode ser cadastrada, se false, não pode ser cadastrada.</returns>
        bool ValidarConsulta(Consultas consulta);

        /// <summary>
        /// Transforma uma lista de Consultas em uma lista de ConsultasViewModel,
        /// para que os dados possam ser retornados da API em segurança.
        /// </summary>
        /// <param name="consultas">Consultas</param>
        /// <returns>Uma lista de ConsultasViewModel</returns>
        List<ConsultasViewModel> TransformaEmConsultasViewModel(List<Consultas> consultas);

        /// <summary>
        /// Transforma uma lista de ConsultasViewModel em uma lista de ConsultaLocalidadeViewModel,
        /// para que os dados possam ser retornados da API em segurança.
        /// </summary>
        /// <param name="consultas">ConsultasViewModel</param>
        /// <returns>Uma lista de ConsultasViewModel</returns>
        List<ConsultaLocalidadeViewModel> TransformaEmConsultaLocalidadeViewModel(List<ConsultasViewModel> consultas);

        /// <summary>
        /// Listar as localizações das consultas.
        /// </summary>
        /// <returns>A localização da consulta, junto com os dados referentes à ela.</returns>
        List<ConsultaLocalidadeViewModel> ListarConsultasLocalidade();

        /// <summary>
        /// Cadastrar a localização de uma consulta. Obs: Junto com seu id.
        /// </summary>
        /// <param name="consulta">ConsultaLocalização Object.</param>
        void CadastrarConsultaLocalidade(ConsultaLocalizacao consulta);

        /// <summary>
        /// Listar ConsultaLocalidadeViewModel por usuário logado.
        /// </summary>
        /// <returns></returns>
        List<ConsultaLocalidadeViewModel> ListarConsultasLocalidadePorPaciente(Pacientes paciente);

        /// <summary>
        /// Listar ConsultaLocalidadeVIewMode por id médico.
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        List<ConsultaLocalidadeViewModel> ListarConsultasLocalidadePorMedico(Medicos medico);
    }
}
