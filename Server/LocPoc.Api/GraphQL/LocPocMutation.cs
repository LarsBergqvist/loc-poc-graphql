using GraphQL.Types;
using LocPoc.Api.GraphQL.Types;

using LocPoc.Contracts;

namespace LocPoc.Api.GraphQL
{
    public class LocPocMutation: ObjectGraphType
    {
        public LocPocMutation(ILocationsRepositoryAsync repository)
        {
            FieldAsync<LocationType>(
                "createLocation",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LocationInputType>> { Name = "location" }),
                resolve: async context =>
                {
                    var location = context.GetArgument<Location>("location");
                    return await context.TryAsyncResolve(
                        async c => await repository.CreateAsync(location));
                });
        }
    }
}
