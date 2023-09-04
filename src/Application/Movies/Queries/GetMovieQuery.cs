using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Movies.Queries;
public record GetMovieQuery(int Id) : IRequest<MovieDto>;
public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetMovieQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie =  await _context.Movies.Where(m => m.Id == request.Id).Include(M => M.Director).FirstOrDefaultAsync();
        var movievm = _mapper.Map<MovieDto>(movie);
        return movievm;
    }
}
