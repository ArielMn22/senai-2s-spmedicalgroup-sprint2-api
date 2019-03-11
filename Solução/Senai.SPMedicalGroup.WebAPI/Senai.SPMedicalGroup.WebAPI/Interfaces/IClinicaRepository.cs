using Senai.SPMedicalGroup.WebAPI.Domains;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IClinicaRepository
    {
        /// <summary>
        /// Cadastra os dados de uma clínica.
        /// </summary>
        /// <param name="clinica"></param>
        void CadastrarDados(Clinica clinica);

        /// <summary>
        /// Atualiza os dados da clínica.
        /// Receberá o Id da clínica a ser atualizada por meio do body.
        /// </summary>
        /// <param name="clinica">Objeto do tipo clinica.</param>
        void AtualizarDados(Clinica novaClinica, Clinica clinicaCadastrada);

        /// <summary>
        /// Busca uma clínica por Id.
        /// </summary>
        /// <param name="idClinica">Id primário da clínica.</param>
        /// <returns>Retorna uma clínica.</returns>
        Clinica BuscarClinicaPorId(int idClinica);
    }
}
