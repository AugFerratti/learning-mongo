using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class listandoDocumentosFiltroBson
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
            var conexaoBiblioteca = new conectandoMongoDB();
            Console.WriteLine("Listando documentos");

            var Filtro = new BsonDocument();

            var listaLivros = await conexaoBiblioteca.Livros.Find(Filtro).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando documentos Autor = Machado de Assis");

            Filtro = new BsonDocument
           {
               {"Autor", "Machado de Assis" }
           };

            listaLivros = await conexaoBiblioteca.Livros.Find(Filtro).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");
        }
    }
}
