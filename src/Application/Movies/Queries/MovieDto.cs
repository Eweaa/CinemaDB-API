using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Movies.Queries;
public class MovieDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int DirectorId { get; set; }
    public string? DirectorName { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(des => des.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(des => des.DirectorName, opt => opt.MapFrom(src => src.Director.Name)).ReverseMap();
        }
    }
}
