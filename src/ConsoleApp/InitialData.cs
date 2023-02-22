using ConsoleApp;
using ConsoleApp.Models;

public class InitialData
{
    private readonly AppDbContext _context;

    public InitialData(AppDbContext context)
    {
        _context = context;
    }

    public void CreateInitialData()
    {
        if (_context.Estudante.Any()) return;
        if (_context.Disciplina.Any()) return;
        if (_context.EstudanteDisciplina.Any()) return;

        var estudantes = new Estudante[]
        {
            new Estudante(1, "Estudante 1", "estudante1@email.com", "640ca087"),
            new Estudante(2, "Estudante 2", "estudante2@email.com", "9a614b77"),
            new Estudante(3, "Estudante 3", "estudante3@email.com", "ab35a799"),
            new Estudante(4, "Estudante 4", "estudante4@email.com", "f0fbd2d6")
        };

        var disciplinas = new Disciplina[]
        {
            new(1, "Matemática"),
            new(2, "História"),
            new(3, "Geografia")
        };

        var estudantesDisciplinas = new EstudanteDisciplina[]
        {
            new EstudanteDisciplina(estudanteId: 1, disciplinaId: 2, nota: 5),
            new EstudanteDisciplina(estudanteId: 1, disciplinaId: 3, nota: 8.3),
            new EstudanteDisciplina(estudanteId: 2, disciplinaId: 1, nota: 6.9),
            new EstudanteDisciplina(estudanteId: 2, disciplinaId: 3, nota: 8.9),
            new EstudanteDisciplina(estudanteId: 3, disciplinaId: 1, nota: 4.5),
            new EstudanteDisciplina(estudanteId: 3, disciplinaId: 2, nota: 9),
            new EstudanteDisciplina(estudanteId: 3, disciplinaId: 3, nota: 7.8)
        };

        _context.Estudante.AddRange(estudantes);
        _context.Disciplina.AddRange(disciplinas);
        _context.EstudanteDisciplina.AddRange(estudantesDisciplinas);

        _context.SaveChanges();
    }
}
