using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfTech.Models {
    public class FormularioModel {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        [BsonRequired]
        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonRequired]
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("profissao")]
        public string Profissao { get; set; }

        [BsonElement("experiencia")]
        public string Experiencia { get; set; }

        [BsonElement("checkbox")]
        public string Checkbox { get; set; }

        public bool InscricaoValida(string nome, string email) {
            Nome = nome;
            Email = email;
            if (Nome == null || Email == null) {
                return false;
            }
            return true;
        }

    }
}
