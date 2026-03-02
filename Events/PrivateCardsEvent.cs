using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events
{
    public class PrivateCardsEvent : NetworkMessage, IEvent
    {
        public List<CardDto> Cards { get; set; } // The two hole cards
    }
}