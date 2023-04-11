namespace AulaCrud.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public DateTime? DataLancamento { get; set; }
}