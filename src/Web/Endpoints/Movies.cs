using CinemaDB.Application.Movies.Commands.CreateMovie;
using CinemaDB.Application.Movies.Commands.DeleteMovie;
using CinemaDB.Application.Movies.Commands.UpdateMovie;
using CinemaDB.Application.Movies.Queries.GetMovie;
using CinemaDB.Application.Movies.Queries.GetMovieActorsQuery;
using CinemaDB.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CinemaDB.Web.Endpoints;

public class Movies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetMovies)
            .MapGet(GetMovie, "{id}")
            .MapGet(GetMovieActors, "actors/{id}")
            .MapPost(CreateMovie)
            .MapPut(UpdateMovie, "{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteMovie, "{id}");
    }

    public async Task<List<MovieDto>> GetMovies(ISender sender, [AsParameters] GetMovieListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<MovieDto> GetMovie(ISender sender, [AsParameters] GetMovieQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<MovieActorsDto>> GetMovieActors(ISender sender, [AsParameters] GetMovieActorListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateMovie(ISender sender, CreateMovieCommand command)
    { 
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateMovie(ISender sender, int id, UpdateMovieCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteMovie(ISender sender, int id)
    {
        await sender.Send(new DeleteMovieCommand(id));
        return Results.NoContent();
    }
}
