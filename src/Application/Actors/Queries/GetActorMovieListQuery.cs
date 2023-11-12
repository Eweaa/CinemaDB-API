using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Actors.Queries;
public record GetActorMovieListQuery(int Id) : IRequest<List<ActorMoviesDto>>;
public class GetActorMovieListQueryHandler : IRequestHandler<GetActorMovieListQuery, List<ActorMoviesDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetActorMovieListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ActorMoviesDto>> Handle(GetActorMovieListQuery request, CancellationToken cancellationToken)
    {
        var actormovies = await _context.ActorMovies.Where(a => a.ActorId == request.Id).Include(m => m.Movie).ToListAsync();
        var actormoviesVM = _mapper.Map<List<ActorMoviesDto>>(actormovies);
        return actormoviesVM;
    }
}
