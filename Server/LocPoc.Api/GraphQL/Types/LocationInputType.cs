using GraphQL.Types;

namespace LocPoc.Api.GraphQL.Types
{
    public class LocationInputType: InputObjectGraphType
    {
        public LocationInputType()
        {
            Name = "locationInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<FloatGraphType>>("latitude");
            Field<NonNullGraphType<FloatGraphType>>("longitude");
        }
    }
}
