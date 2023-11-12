using CinemaDB.Application.Common.Interfaces;

namespace CinemaDB.Application.Movies.Commands.UpdateMovie;
public record UpdateMovieCommand : IRequest
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public DateTime? ReleaseDate { get; init; }
    public int DirectorId { get; init; }
}
public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies.FindAsync(new object[] { request.Id }, cancellationToken);

        if (request.Title != null && request.Title != string.Empty)
        {
            entity!.Name = request.Title;
        }
        
        if (request.ReleaseDate != null)
        {
            entity!.ReleaseDate = request.ReleaseDate;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
