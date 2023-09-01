using CinemaDB.Application.Actors.Commands.CreateActor;
using CinemaDB.Application.Actors.Commands.DeleteActor;
using CinemaDB.Application.Actors.Queries;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Web.Endpoints;

public class Actors : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetActors)
            .MapPost(CreateActor)
            //.MapPut(UpdateTodoItem, "{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteActor, "{id}");
    }

    public async Task<List<Actor>> GetActors(ISender sender, [AsParameters] GetActorListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateActor(ISender sender, CreateActorCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> DeleteActor(ISender sender, int id)
    {
        await sender.Send(new DeleteActorCommand(id));
        return Results.NoContent();
    }
}
