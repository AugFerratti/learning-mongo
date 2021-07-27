using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace exemplos_mongodb
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Páginas { get; set; }
        public List<string> Assunto { get; set; }
    }
}
