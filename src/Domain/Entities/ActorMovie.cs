namespace CinemaDB.Domain.Entities;
public class ActorMovie
{
    public int Id { get; set; }
    public int ActorId { get; set; }
    public virtual Actor? Actor { get; set; }
    public int MovieId { get; set; }
    public virtual Movie? Movie { get; set; }
}
