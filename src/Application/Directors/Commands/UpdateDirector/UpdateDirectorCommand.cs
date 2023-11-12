using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Directors.Commands.UpdateDirector;
public record UpdateDirectorCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public DateTime? Birthdate { get; init; }
}
public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateDirectorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Directors.FindAsync(new object[] { request.Id }, cancellationToken);

        if (request.Name != null && request.Name != string.Empty)
        {
            entity!.Name = request.Name;
        }

        if (request.Birthdate != null)
        {
            entity!.Birthdate = request.Birthdate;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
