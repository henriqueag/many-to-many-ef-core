namespace ConsoleApp.Models;

public class EstudanteDisciplina
{
    public EstudanteDisciplina()
    {
    }

    public EstudanteDisciplina(int estudanteId, int disciplinaId, double nota)
    {
        EstudanteId = estudanteId;
        DisciplinaId = disciplinaId;
        Nota = nota;
        Aprovado = nota > 6;
    }

    public double Nota { get; set; }
    public bool Aprovado { get; set; }

    public int EstudanteId { get; set; }
    public Estudante Estudante { get; set; }

    public int DisciplinaId { get; set; }
    public Disciplina Disciplina { get; set; }
}
