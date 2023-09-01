using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Movies.Commands.CreateMovie;
public record CreateMovieCommand : IRequest<int>
{
    public string? Name { get; init; }
    public int DirectorId { get; init; }
}

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context) { _context = context; }

    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = new Movie
        {
            Name = request.Name,
            DirectorId = request.DirectorId,
        };

        _context.Movies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
