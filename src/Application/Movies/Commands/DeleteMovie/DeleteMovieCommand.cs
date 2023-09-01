using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Movies.Commands.DeleteMovie;
public record DeleteMovieCommand(int Id) : IRequest;
public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IApplicationDbContext _context;
    public DeleteMovieCommandHandler(IApplicationDbContext context) { _context = context; }
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            return;
        }

        _context.Movies.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
