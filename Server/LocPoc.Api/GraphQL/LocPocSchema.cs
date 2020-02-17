using GraphQL;
using GraphQL.Types;

namespace LocPoc.Api.GraphQL
{
    public class LocPocSchema: Schema
    {
        public LocPocSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<LocPocQuery>();
            Mutation = resolver.Resolve<LocPocMutation>();
            Subscription = resolver.Resolve<LocPocSubscription>();
        }
    }
}
