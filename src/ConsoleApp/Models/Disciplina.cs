namespace ConsoleApp.Models;

public class Disciplina
{
    public Disciplina(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<EstudanteDisciplina> Estudantes { get; set; }
}
