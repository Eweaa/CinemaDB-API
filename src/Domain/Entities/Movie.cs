namespace CinemaDB.Domain.Entities;
public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int DirectorId { get; set; }
    public Director Director { get; set; } = null!;
    //public ICollection<Actor>? Actors { get; set; }
    public ICollection<ActorMovie>? EActors { get; set; }
}
