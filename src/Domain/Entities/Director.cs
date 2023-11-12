namespace CinemaDB.Domain.Entities;
public class Director
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? Birthdate { get; set; }
    public ICollection<Movie>? Movies { get; set; }
    //public ICollection<Movie>? Movies { get; } = new List<Movie>();
}
