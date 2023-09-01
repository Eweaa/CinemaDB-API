using CinemaDB.Application.Movies.Commands.CreateMovie;
using CinemaDB.Application.Movies.Commands.DeleteMovie;
using CinemaDB.Application.Movies.Queries;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Web.Endpoints;

public class Movies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetMovies)
            .MapPost(CreateMovie)
            //.MapPut(UpdateTodoItem, "{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteMovie, "{id}");
    }

    public async Task<List<Movie>> GetMovies(ISender sender, [AsParameters] GetMovieListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateMovie(ISender sender, CreateMovieCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> DeleteMovie(ISender sender, int id)
    {
        await sender.Send(new DeleteMovieCommand(id));
        return Results.NoContent();
    }
}
