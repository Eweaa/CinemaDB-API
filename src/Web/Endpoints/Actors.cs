using CinemaDB.Application.Actors.Commands.CreateActor;
using CinemaDB.Application.Actors.Commands.DeleteActor;
using CinemaDB.Application.Actors.Commands.UpdateActor;
using CinemaDB.Application.Actors.Queries;
using CinemaDB.Application.TodoItems.Commands.UpdateTodoItem;
using CinemaDB.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CinemaDB.Web.Endpoints;

public class Actors : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetActors)
            .MapGet(GetActorMovies, "movies/{Id}")
            .MapPost(CreateActor)
            .MapPut(UpdateActor, "update/{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteActor, "delete/{id}");
    }

    public async Task<List<Actor>> GetActors(ISender sender, [AsParameters] GetActorListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<ActorMoviesDto>> GetActorMovies(ISender sender, [AsParameters] GetActorMovieListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateActor(ISender sender, CreateActorCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateActor(ISender sender, int id, UpdateActorCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteActor(ISender sender, int id)
    {
        await sender.Send(new DeleteActorCommand(id));
        return Results.NoContent();
    }
}
