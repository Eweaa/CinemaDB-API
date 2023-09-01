using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Directors.Queries;
public record GetDirectorListQuery : IRequest<List<Director>>;
public class GetDirectorListQueryHandler : IRequestHandler<GetDirectorListQuery, List<Director>>
{
    private readonly IApplicationDbContext _context;
    public GetDirectorListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public Task<List<Director>> Handle(GetDirectorListQuery request, CancellationToken cancellationToken)
    {
        return _context.Directors.ToListAsync();
    }
}
