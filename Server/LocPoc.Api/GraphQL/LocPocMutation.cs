using GraphQL.Types;
using LocPoc.Api.GraphQL.Types;
using LocPoc.Api.GraphQL.Messaging;
using LocPoc.Contracts;

namespace LocPoc.Api.GraphQL
{
    public class LocPocMutation: ObjectGraphType
    {
        public LocPocMutation(ILocationsRepositoryAsync repository, LocationMessageService messageService)
        {
            FieldAsync<LocationType>(
                "createLocation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LocationInputType>> { Name = "location" }),
                resolve: async context =>
                {
                    var location = context.GetArgument<Location>("location");
                    await repository.CreateAsync(location);
                    messageService.AddLocationAddedMessage(location);
                    return location;
                });
        }
    }
}
