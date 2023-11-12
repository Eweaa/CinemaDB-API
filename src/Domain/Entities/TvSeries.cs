namespace CinemaDB.Domain.Entities;
public class TvSeries
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? ReleaseDate { get; set; }
    //public string? Description { get; set; }
    public ICollection<Season> Seasons { get; set; } = new List<Season>();
}
