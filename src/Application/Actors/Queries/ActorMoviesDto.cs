using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Actors.Queries;
public class ActorMoviesDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string? MovieTitle { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ActorMovie, ActorMoviesDto>()
                .AfterMap((src, dest) => dest.MovieId = src.Movie!.Id)
                .AfterMap((src, dest) => dest.MovieTitle = src.Movie?.Name);
        }
    }
}
