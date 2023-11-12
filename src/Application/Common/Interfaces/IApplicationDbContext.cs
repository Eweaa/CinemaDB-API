using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Actor> Actors { get; }
    DbSet<Director> Directors { get; }
    DbSet<Movie> Movies { get; }
    DbSet<ActorMovie> ActorMovies { get; }
    DbSet<TvSeries> TvSeries { get; }
    DbSet<Season> Seasons { get; }
    DbSet<Episode> Episodes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
