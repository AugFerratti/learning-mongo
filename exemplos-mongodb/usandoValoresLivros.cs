using System;
using System.Threading.Tasks;

namespace exemplos_mongodb
{
    class usandoValoresLivros
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

            Livro livro = new Livro();
            livro = valoresLivro.incluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura Brasileira");
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);


            Livro livro2 = new Livro();
            livro2 = valoresLivro.incluiValoresLivro("A arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");
            await conexaoBiblioteca.Livros.InsertOneAsync(livro2);

            Console.WriteLine("Documento incluído.");
        }
    }
}
