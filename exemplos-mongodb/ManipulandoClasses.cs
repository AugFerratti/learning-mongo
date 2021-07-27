using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class ManipulandoClasses
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
            //inicializar uma variável do tipo objeto livro

            Livro livro = new Livro();
            livro.Título = "Sob a redoma";
            livro.Autor = "Stephan King";
            livro.Ano = 2012;
            livro.Páginas = 679;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção científica");
            listaAssuntos.Add("Terror");
            listaAssuntos.Add("Ação");

            livro.Assunto = listaAssuntos;

            //acesso ao servidor do MongoDB

            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados

            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso a coleção

            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            //incluindo documento

            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento incluído.");
        }
    }
}
