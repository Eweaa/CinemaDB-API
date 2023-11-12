using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.TvSeriesA.Queries;
public record GetTvSeriesListQuery : IRequest<List<TvSeries>>;
public class GetTvSeriesListQueryHandler : IRequestHandler<GetTvSeriesListQuery, List<TvSeries>>
{
    private readonly IApplicationDbContext _context;
    public GetTvSeriesListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public Task<List<TvSeries>> Handle(GetTvSeriesListQuery request, CancellationToken cancellationToken)
    {
        return _context.TvSeries.Include(t => t.Seasons).ToListAsync();
    }
}
