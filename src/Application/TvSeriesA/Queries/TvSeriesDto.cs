using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.TvSeriesA.Queries;
public class TvSeriesDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? Description { get; set; }
    public ICollection<SeasonDto>? Seasons { get; set; }
}
