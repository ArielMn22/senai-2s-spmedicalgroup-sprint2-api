using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public class ConsultaLocalizacao
    {
        //Domain criado para o cadastro de localizações de onde as consultas serão realizadas.

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("latitude")]
        public float Latitude { get; set; }

        [BsonRequired]
        [BsonElement("longitude")]
        public float Longitude { get; set; }

        [BsonRequired]
        [BsonElement("idConsulta")]
        public int IdConsulta { get; set; }
    }
}
