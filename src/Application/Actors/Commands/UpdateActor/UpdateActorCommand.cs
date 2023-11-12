using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Actors.Commands.UpdateActor;
public record UpdateActorCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public DateTime? Birthdate { get; set; }
}
public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateActorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Actors.FindAsync(new object[] { request.Id }, cancellationToken);

        if(request.Name != null && request.Name != string.Empty)
        {
            entity!.Name = request.Name;
        }

        if(request.Birthdate != null)
        {
            entity!.Birthdate = request.Birthdate;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
