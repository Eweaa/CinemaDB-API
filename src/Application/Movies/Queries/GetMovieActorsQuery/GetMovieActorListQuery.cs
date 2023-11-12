using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Movies.Queries.GetMovieActorsQuery;
public record GetMovieActorListQuery(int Id) : IRequest<List<MovieActorsDto>>;
public class GetMovieActorListQueryHandler : IRequestHandler<GetMovieActorListQuery, List<MovieActorsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetMovieActorListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MovieActorsDto>> Handle(GetMovieActorListQuery request, CancellationToken cancellationToken)
    {
        var movieactors = await _context.ActorMovies.Where(a => a.MovieId == request.Id).Include(m => m.Actor).ToListAsync();
        var movieactorsVM = _mapper.Map<List<MovieActorsDto>>(movieactors);
        return movieactorsVM!;
    }
}
