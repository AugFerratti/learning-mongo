using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class listandoDocumentosOrdem
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

            Console.WriteLine("Listando documentos Páginas > 100, Ordenado por título e com limite de 5 docs");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gt(x => x.Páginas, 100);

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).SortBy(x => x.Título).Limit(5).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");
        }
    }
}
