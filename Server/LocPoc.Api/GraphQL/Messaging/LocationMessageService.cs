using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using LocPoc.Contracts;

namespace LocPoc.Api.GraphQL.Messaging
{
    public class LocationMessageService
    {
        private readonly ISubject<LocationAddedMessage> _messageStream = new ReplaySubject<LocationAddedMessage>(1);

        public LocationAddedMessage AddLocationAddedMessage(Location location)
        {
            var message = new LocationAddedMessage
            {
                Id = location.Id,
                Name = location.Name
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<LocationAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}
