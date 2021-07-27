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

    public class valoresLivro
    {


        public static Livro incluiValoresLivro(string Titulo, string Autor, int Ano, int Paginas, string Assuntos)
        {
            Livro livro = new Livro();
            livro.Título = Titulo;
            livro.Autor = Autor;
            livro.Ano = Ano;
            livro.Páginas = Paginas;
            string[] vetAssunto = Assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();
            for (int i = 0; i <= vetAssunto.Length - 1; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }
            livro.Assunto = vetAssunto2;
            return livro;
        }
    }
}