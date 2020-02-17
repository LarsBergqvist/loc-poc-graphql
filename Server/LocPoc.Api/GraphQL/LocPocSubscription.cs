using GraphQL.Resolvers;
using GraphQL.Types;
using LocPoc.Api.GraphQL.Messaging;

namespace LocPoc.Api.GraphQL
{
    public class LocPocSubscription: ObjectGraphType
    {
        public LocPocSubscription(LocationMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "locationAdded",
                Type = typeof(LocationAddedMessageType),
                Resolver = new FuncFieldResolver<LocationAddedMessage>(c => c.Source as LocationAddedMessage),
                Subscriber = new EventStreamResolver<LocationAddedMessage>(c => messageService.GetMessages())
            });
        }
    }
}
