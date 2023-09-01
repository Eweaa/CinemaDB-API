using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;
using CinemaDB.Domain.Events;

namespace CinemaDB.Application.Actors.Commands.CreateActor;
public record CreateActorCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateActorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var entity = new Actor
        {
            Name = request.Name
        };

        _context.Actors.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
