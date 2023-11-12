using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.TvSeriesA.Queries;
public class SeasonDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<EpisodeDto>? Episodes { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Season, SeasonDto>();
        }
    }
}
