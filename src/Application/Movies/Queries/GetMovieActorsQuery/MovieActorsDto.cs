using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Movies.Queries.GetMovieActorsQuery;
public class MovieActorsDto
{
    public int Id { get; set; }
    public int ActorId { get; set; }
    public string? ActorName { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ActorMovie, MovieActorsDto>()
                .AfterMap((src, dest) => dest.ActorId = src.Actor!.Id)
                .AfterMap((src, dest) => dest.ActorName = src.Actor?.Name);
        }
    }
}
