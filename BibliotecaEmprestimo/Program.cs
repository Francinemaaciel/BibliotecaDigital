using System;
using BibliotecaEmprestimo.Models;

namespace BibliotecaEmprestimo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n---- Biblioteca Digital ----\n");
                Console.WriteLine("1 - Listar Livros");
                Console.WriteLine("2 - Adicionar um livro");
                Console.WriteLine("3 - Emprestar um livro");
                Console.WriteLine("4 - Devolver um livro");
                Console.WriteLine("5 - Excluir um livro");
                Console.WriteLine("6 - Sair");
                Console.Write("\nEscolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarLivros();
                        break;

                    case "2":
                        AdicionarLivro();
                        break;

                    case "3":
                        EmprestarLivro();
                        break;

                    case "4":
                        DevolverLivro();
                        break;

                    case "5":
                        ExcluirLivro();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }
        }

        static void ListarLivros()
        {
            using (var context = new BibliotecaContext())
            {
                var livros = context.Livros.ToList();
                Console.WriteLine("\n---- Lista de Livros ----");
                foreach (var livro in livros)
                {
                    Console.WriteLine($"\n ID: {livro.Id}\n Título: {livro.Titulo}\n Autor: {livro.Autor}\n Ano de Lançamento: {livro.Ano}\n Descrição: {livro.Descricao}\n Status: {(livro.Disponivel ? "Disponível" : "Emprestado")}");
                }
                Console.WriteLine();
            }
        }

        static void AdicionarLivro()
        {
            Console.Write("Nome do Livro: ");
            var titulo = Console.ReadLine();
            Console.Write("Autor: ");
            var autor = Console.ReadLine();
            Console.Write("Ano de Lançamento: ");
            var ano = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            var descricao = Console.ReadLine();

            using (var context = new BibliotecaContext())
            {
                var livro = new Livro { Titulo = titulo, Autor = autor, Ano = ano, Descricao = descricao };
                context.Livros.Add(livro);
                context.SaveChanges();
            }

            Console.WriteLine($"\nLivro: {titulo} adicionado com sucesso!");
        }

        static void EmprestarLivro()
        {
            Console.Write("ID do Livro: ");
            var id = int.Parse(Console.ReadLine());

            using (var context = new BibliotecaContext())
            {
                var livro = context.Livros.Find(id);
                if (livro != null)
                {
                    livro.Disponivel = false; // Livro emprestado (não disponível)
                    context.SaveChanges();
                    Console.WriteLine($"\nLivro: {livro.Titulo} emprestado com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nLivro não encontrado, tente novamente.");
                }
            }
        }

        static void DevolverLivro()
        {
            Console.Write("\nID do Livro: ");
            var id = int.Parse(Console.ReadLine());

            using (var context = new BibliotecaContext())
            {
                var livro = context.Livros.Find(id);
                if (livro != null)
                {
                    livro.Disponivel = true; // Livro devolvido (disponível)
                    context.SaveChanges();
                    Console.WriteLine($"\nLivro: {livro.Titulo} devolvido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nLivro não encontrado.");
                }
            }
        }

        static void ExcluirLivro()
        {
            Console.Write("ID do Livro: ");
            var id = int.Parse(Console.ReadLine());

            using (var context = new BibliotecaContext())
            {
                var livro = context.Livros.Find(id);
                if (livro != null)
                {
                    context.Livros.Remove(livro);
                    context.SaveChanges();
                    Console.WriteLine("Livro removido com Sucesso!");
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
        }
    }
}