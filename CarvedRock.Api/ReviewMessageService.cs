using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using CarvedRock.Data.Entities;
using CarvedRock.GraphQL.Messaging;

namespace CarvedRock
{
    public class ReviewMessageService
    {
        private readonly ISubject<ReviewAddedMessage> _messageStream = new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(ProductReview review)
        {
            var message = new ReviewAddedMessage
            {
                ProductId = review.ProductId,
                Title = review.Title
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<ReviewAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}