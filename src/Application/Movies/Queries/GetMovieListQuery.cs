using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Movies.Queries;
public record GetMovieListQuery : IRequest<List<MovieDto>>;
public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetMovieListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.Movies.Include(M => M.Director).ToListAsync();
        var moviesvm = _mapper.Map<List<MovieDto>>(data);
        return moviesvm;
    }
}
