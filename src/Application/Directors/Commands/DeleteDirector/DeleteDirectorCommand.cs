using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Directors.Commands.DeleteDirector;
public record DeleteDirectorCommand(int Id) : IRequest;

public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDirectorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Directors.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null) 
        {
            return;
        }

        _context.Directors.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
