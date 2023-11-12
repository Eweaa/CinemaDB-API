  namespace CinemaDB.Domain.Entities;
public class Episode
{
    public int Id { get; set; }
    public string? Name { get; set; }
    //public string? Description { get; set; }
    public int SeasonId { get; set; }
    //public Season? Season { get; set; }
    public Season Season { get; set; } = null!;
}
