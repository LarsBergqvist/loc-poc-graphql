using LocPoc.Api.GraphQL.Messaging;
using GraphQL.Types;

namespace LocPoc.Api.GraphQL
{
    public class LocationAddedMessageType: ObjectGraphType<LocationAddedMessage>
    {
        public LocationAddedMessageType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}
