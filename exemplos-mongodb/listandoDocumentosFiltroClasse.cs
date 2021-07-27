using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplos_mongodb
{
    class listandoDocumentosFiltroClasse
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

            Console.WriteLine("Listando documentos Autor = Machado de Assis");

            var Filtro = new BsonDocument
           {
               {"Autor", "Machado de Assis" }
           };

            var listaLivros = await conexaoBiblioteca.Livros.Find(Filtro).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando documentos Autor = Machado de Assis - Classe");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach(var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando documentos Ano de publicacao >= a 1999");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 1999);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando documentos Ano de publicacao a partir de 1999 e que tenham mais de 300 páginas");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gt(x => x.Páginas, 300);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando documentos Todos os livros de Ficção científica");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.AnyEq(x => x.Assunto, "Ficção Científica");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista");
        }
    }
}
