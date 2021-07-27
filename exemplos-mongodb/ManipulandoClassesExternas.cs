using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace exemplos_mongodb
{
    class ManipulandoClassesExternas
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
            livro.Título = "Star Wars Legends";
            livro.Autor = "Timothy Zahn";
            livro.Ano = 2010;
            livro.Páginas = 245;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção científica");
            listaAssuntos.Add("Ação");

            livro.Assunto = listaAssuntos;

            //Acessando através da classe de conexão

            var conexaoBiblioteca = new conectandoMongoDB();

            await conexaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento incluído.");
        }
    }
}