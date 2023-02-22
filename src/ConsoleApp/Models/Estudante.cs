namespace ConsoleApp.Models;

public class Estudante
{
    public Estudante(int id, string nome, string email, string matricula)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Matricula = matricula;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Matricula { get; set; }

    public virtual ICollection<EstudanteDisciplina> Disciplinas { get; set; }
}