using CinemaDB.Application.Directors.Commands.CreateDirector;
using CinemaDB.Application.Directors.Commands.DeleteDirector;
using CinemaDB.Application.Directors.Commands.UpdateDirector;
using CinemaDB.Application.Directors.Queries;
using CinemaDB.Domain.Entities;

namespace CinemaDB.Web.Endpoints;

public class Directors : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetDirectors)
            .MapPost(CreateDirector)
            .MapPut(UpdateDirector, "{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteDirector, "{id}");
    }
    public async Task<List<Director>> GetDirectors(ISender sender, [AsParameters] GetDirectorListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateDirector(ISender sender, CreateDirectorCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateDirector(ISender sender, int id, UpdateDirectorCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteDirector(ISender sender, int id)
    {
        await sender.Send(new DeleteDirectorCommand(id));
        return Results.NoContent();
    }
}
