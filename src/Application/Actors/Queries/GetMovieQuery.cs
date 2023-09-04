using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Actors.Queries;
//public record GetMovieQuery(int Id) : IRequest<Actor>;
//public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, Actor>
//{
//    private readonly IApplicationDbContext _context;
//    public GetMovieQueryHandler(IApplicationDbContext context)
//    {
//        _context = context;
//    }
//    public Task<Actor> Handle(GetMovieQuery request, CancellationToken cancellationToken)
//    {
//        return _context.Actors.Where(A => A.Id == request.Id).FirstOrDefaultAsync();
//    }
//}
