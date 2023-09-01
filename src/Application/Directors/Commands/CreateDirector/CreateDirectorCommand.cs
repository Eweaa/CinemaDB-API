using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Directors.Commands.CreateDirector;
public class CreateDirectorCommand : IRequest<int>
{
    public string? Name { get; init; }
}
public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateDirectorCommandHandler(IApplicationDbContext context) { _context = context; }

    public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = new Director
        {
            Name = request.Name
        };

        _context.Directors.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
