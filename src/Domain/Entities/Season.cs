namespace CinemaDB.Domain.Entities;
public class Season
{
    public int Id { get; set; }
    public string? Name { get; set; }
    //public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<Episode> Episodes { get; } = new List<Episode>();
    public int TvSeriesId { get; set; }
    public TvSeries TvSeries { get; set; } = null!;
    //public TvSeries? TvSeries { get; set; }
}
