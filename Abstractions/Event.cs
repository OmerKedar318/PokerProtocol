using System.Security.Cryptography;
using .EventType;
using System.Text.Json.Serialization;

namespace Poker.Protocol.Abstractions
{
    public abstract class Event {
        [JsonPropertyName("type")]
        public const EventType type;

        public Event(EventType type)
        {
            this.type = type;
        }
    }
}