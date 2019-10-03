using CarvedRock.GraphQL.Messaging;
using CarvedRock.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace CarvedRock.GraphQL
{
    public class CarvedRockSubscription : ObjectGraphType
    {
        public CarvedRockSubscription(ReviewMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageType),
                Resolver = new FuncFieldResolver<ReviewAddedMessage>(c => c.Source as ReviewAddedMessage),
                Subscriber = new EventStreamResolver<ReviewAddedMessage>(c => messageService.GetMessages())
            });
        }
    }
}