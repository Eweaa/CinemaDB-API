using CinemaDB.Application.TvSeriesA.Queries;

namespace CinemaDB.Web.Endpoints;

public class TvSeries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTvSeries);
            //.MapPost(CreateActor)
            //.MapPut(UpdateTodoItem, "{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            //.MapDelete(DeleteActor, "{id}");
    }

    public async Task<List<Domain.Entities.TvSeries>> GetTvSeries(ISender sender, [AsParameters] GetTvSeriesListQuery query)
    {
        return await sender.Send(query);
    }
}
