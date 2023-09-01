using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Events;

namespace CinemaDB.Application.Actors.Commands.DeleteActor;
public record DeleteActorCommand(int Id) : IRequest;
public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly IApplicationDbContext _context;
    public DeleteActorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Actors
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Actors.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
