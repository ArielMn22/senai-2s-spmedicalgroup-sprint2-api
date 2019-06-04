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
    public class ConsultaLocalizacaoRepository : IConsultaLocalizacaoRepository
    {
        private readonly IMongoCollection<ConsultaLocalizacao> _consultaLocalizacao;

        public ConsultaLocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("spmedicalgroupAriel");
            _consultaLocalizacao = database.GetCollection<ConsultaLocalizacao>("consultas");
        }

        public void Cadastrar(ConsultaLocalizacao consulta)
        {
            _consultaLocalizacao.InsertOne(consulta);
        }

        public List<ConsultaLocalidadeViewModel> Listar()
        {
            return _consultaLocalizacao.Find(async => true).ToList();
        }
    }
}
