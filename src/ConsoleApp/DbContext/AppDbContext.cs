using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext()
    {
    }

    public DbSet<Estudante> Estudante => Set<Estudante>();
    public DbSet<Disciplina> Disciplina => Set<Disciplina>();
    public DbSet<EstudanteDisciplina> EstudanteDisciplina => Set<EstudanteDisciplina>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=C:\\Temp\\console-app\\src\\ConsoleApp\\db\\ConsoleApp.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Estudante>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Estudante>()
            .HasMany<EstudanteDisciplina>(x => x.Disciplinas)
            .WithOne(x => x.Estudante)
            .HasForeignKey(x => x.EstudanteId);

        modelBuilder.Entity<Disciplina>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Disciplina>()
            .HasMany<EstudanteDisciplina>(x => x.Estudantes)
            .WithOne(x => x.Disciplina)
            .HasForeignKey(x => x.DisciplinaId);

        modelBuilder.Entity<EstudanteDisciplina>()
            .HasKey(x => new { x.EstudanteId, x.DisciplinaId });
    }
}
