using ConsoleApp;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDbContext<AppDbContext>()
    .BuildServiceProvider();

var context = services.GetRequiredService<AppDbContext>();

var estudantes = context.Estudante
    .Include(x => x.Disciplinas)
    .ThenInclude(x => x.Disciplina)
    .ToList();

var disciplinas = context.Disciplina
    .Include(x => x.Estudantes)
    .ThenInclude(x => x.Estudante)
    .ToList();

foreach(var estudante in estudantes)
{
    Console.WriteLine($"Disciplinas do {estudante.Nome}:");
    foreach(var disciplina in estudante.Disciplinas)
    {
        Console.WriteLine($"{disciplina.Disciplina.Id}, {disciplina.Disciplina.Nome}, {(disciplina.Aprovado ? "Aprovado" : "Reprovado")}");
    }

    Console.WriteLine();
}

Console.WriteLine("".PadLeft(55, '='));

foreach(var disciplina in disciplinas)
{
    Console.WriteLine($"Estudantes da disciplina {disciplina.Nome}");
    foreach(var estudante in disciplina.Estudantes)
    {
        Console.WriteLine($"{estudante.Estudante.Nome}, {estudante.Estudante.Matricula}, {estudante.Nota}");
    }

    Console.WriteLine();
}