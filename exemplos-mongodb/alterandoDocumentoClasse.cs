using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class alterandoDocumentoClasse
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
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);
            await conexaoBiblioteca.Livros.UpdateOneAsync(condicao, condicaoAlteracao);

            Console.WriteLine("Registro alterado");

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
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listar os livros de Machado de Assis");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");

            construtorAlteracao = Builders<Livro>.Update;
            condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "M. Assis");
            await conexaoBiblioteca.Livros.UpdateManyAsync(condicao, condicaoAlteracao);

            Console.WriteLine("Registro alterado");
        }
    }
}
