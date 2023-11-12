using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.TvSeriesA.Queries;
public class EpisodeDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Episode, EpisodeDto>();
        }
    }
}
