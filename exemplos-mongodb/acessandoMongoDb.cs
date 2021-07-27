using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class acessandoMongoDb
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine();
            Console.WriteLine("Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            var doc = new BsonDocument
            {
                {"Título", "Guerra dos Tronos" }
            };

            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Páginas", 856);

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");

            Console.WriteLine(doc);

            //acesso ao servidor do MongoDB

            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados

            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso a coleção

            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("Livros");

            //incluindo documento

            await colecao.InsertOneAsync(doc);

            Console.WriteLine("Documento incluído.");
        }
    }
}
