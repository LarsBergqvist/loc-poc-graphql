using LocPoc.Contracts;
using GraphQL.Types;
using LocPoc.Api.GraphQL.Types;

namespace LocPoc.Api.GraphQL
{
    public class LocPocQuery: ObjectGraphType
    {
        public LocPocQuery(ILocationsRepositoryAsync repository)
        {
            Field<ListGraphType<LocationType>>(
                "locations",
                resolve: context => repository.GetAllAsync()
            );
        }
    }
}
