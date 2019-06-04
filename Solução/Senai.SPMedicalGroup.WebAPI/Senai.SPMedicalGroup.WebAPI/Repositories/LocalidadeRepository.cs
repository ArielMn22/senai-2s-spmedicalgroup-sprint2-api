using MongoDB.Driver;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class LocalidadeRepository : ILocalidadeRepository
    {
        private readonly IMongoCollection<ConsultaLocalizacao> _consultaLocalizacao;

        public LocalidadeRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("spmedicalgroupAriel");
            _consultaLocalizacao = database.GetCollection<ConsultaLocalizacao>("consultas");
        }

        public List<LocalidadeViewModel> Listar()
        {
            List<ConsultaLocalizacao> consultas =  _consultaLocalizacao.Find(async => true).ToList();

            List<LocalidadeViewModel> localidades = new List<LocalidadeViewModel>();

            foreach (ConsultaLocalizacao consulta in consultas)
            {
                LocalidadeViewModel localidade = new LocalidadeViewModel()
                {
                    Latitude = consulta.Latitude,
                    Longetude = consulta.Longitude
                };

                localidades.Add(localidade);
            }

            return localidades;
        }
    }
}
