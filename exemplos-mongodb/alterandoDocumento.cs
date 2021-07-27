using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class alterandoDocumento
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

            Console.WriteLine("Listar e alterar o livro Guerra dos Tronos");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Título, "Guerra dos Tronos");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
                doc.Ano = 2000;
                doc.Páginas = 900;
                await conexaoBiblioteca.Livros.ReplaceOneAsync(condicao, doc);
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listar o livro Guerra dos Tronos");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Título, "Guerra dos Tronos");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");
        }
    }
}
