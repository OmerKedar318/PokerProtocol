using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events
{
    public class PrivateCardsEvent : NetworkMessage, IEvent
    {
        private List<CardDto> Cards { get; set; } // The two hole cards

        public PrivateCardsEvent(List<CardDto> cards)
        {
            this.Cards = cards;
        }
    }
}