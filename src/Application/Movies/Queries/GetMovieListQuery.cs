using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Movies.Queries;
public record GetMovieListQuery : IRequest<List<Movie>>;
public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<Movie>>
{
    private readonly IApplicationDbContext _context;
    public GetMovieListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public Task<List<Movie>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
    {
        return _context.Movies.ToListAsync();
    }
}
