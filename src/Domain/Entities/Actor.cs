namespace CinemaDB.Domain.Entities;
public class Actor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? Birthdate { get; set; }
    public ICollection<ActorMovie>? Movies { get; set; }
    //public ICollection<Movie>? Movies { get; set; }
    //public List<Movie> Movies { get; } = new();
}
