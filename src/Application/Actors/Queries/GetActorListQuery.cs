using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Actors.Queries;
public record GetActorListQuery : IRequest<List<Actor>>;
public class GetActorListQueryHandler : IRequestHandler<GetActorListQuery, List<Actor>>
{
    private readonly IApplicationDbContext _context;
    public GetActorListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<Actor>> Handle(GetActorListQuery request, CancellationToken cancellationToken)
    {
        return _context.Actors.ToListAsync();
    }
}
