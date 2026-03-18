using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events;

public class PrivateCardsEvent : BaseEvent
{
    // Override the abstract MsgType from NetworkMessage
    public override string MsgType => MessageType.PrivateCardsEvent;

    // Must be public so the client can actually see the cards in the JSON
    public List<CardDto> Cards { get; set; } = new();

    // Required for the JSON Deserializer
    public PrivateCardsEvent() { }

    public PrivateCardsEvent(List<CardDto> cards)
    {
        Cards = cards;
    }
}