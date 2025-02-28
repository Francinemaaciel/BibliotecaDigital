using BibliotecaEmprestimo.Models;
using Microsoft.EntityFrameworkCore;

public class BibliotecaContext : DbContext
{
    public DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=biblioteca.db");
    }

    public void InicializarBanco()
    {
        Database.EnsureCreated();
    }

}