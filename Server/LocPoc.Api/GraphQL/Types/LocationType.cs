using LocPoc.Contracts;
using GraphQL.Types;

namespace LocPoc.Api.GraphQL.Types
{
    public class LocationType: ObjectGraphType<Location>
    {
        public LocationType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.Latitude);
            Field(t => t.Longitude);
        }
    }
}
