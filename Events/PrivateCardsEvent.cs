using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events
{
    public class PrivateCardsEvent : Event
    {
        private List<CardDto> Cards { get; set; } // The two hole cards

        public PrivateCardsEvent(List<CardDto> cards, EventType type) : base(type)
        {
            this.Cards = cards;
        }
    }
}