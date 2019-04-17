using Senai.SPMedicalGroup.WebAPI.Domains;
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
        List<ConsultasViewModel> ListarTodas();

        /// <summary>
        /// Atualiza uma consulta com as informções passadas.
        /// </summary>
        /// <param name="consulta">Dados de uma consulta.</param>
        void Atualizar(Consultas novaConsulta, Consultas consultaCadastrada);

        /// <summary>
        /// Cadastra uma consulta.
        /// </summary>
        /// <param name="consulta">Um objeto do tipo Consultas.</param>
        void Cadastrar(Consultas consulta);

        /// <summary>
        /// Lista as consultas que possuem o Id do médico passado por parâmetro;
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Uma lista de consultas.</returns>
        List<ConsultasViewModel> ListarPorIdMedico(int idMedico);

        /// <summary>
        /// Lista as consultas que possitem o id do paciente passado por parâmetro.
        /// </summary>
        /// <param name="id">Id do paciente.</param>
        /// <returns>Uma lista de consultas.</returns>
        List<ConsultasViewModel> ListarPorIdPaciente(int idPaciente);

        /// <summary>
        /// Busca um usuário pelo ID.
        /// </summary>
        /// <param name="id">Id da consulta.</param>
        /// <returns>uma Consulta.</returns>
        Consultas BuscarPorId(int id);

        /// <summary>
        /// Valida se a consulta pode ser cadastrada ou não;
        /// </summary>
        /// <param name="consulta">Objeto Consultas</param>
        /// <returns>Se true, pode ser cadastrada, se false, não pode ser cadastrada.</returns>
        bool ValidarConsulta(Consultas consulta);

        /// <summary>
        /// Transforma uma lista de Consultas em uma lista de ConsultasViewModel,
        /// para que os dados possam retornados da API em segurança.
        /// </summary>
        /// <param name="consultas">Consultas</param>
        /// <returns>Uma lista de ConsultasViewModel</returns>
        List<ConsultasViewModel> TransformaEmConsultasViewModel(List<Consultas> consultas);
    }
}
