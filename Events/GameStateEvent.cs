using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events
{
    public class GameStateEvent : NetworkMessage, IEvent
    {
        private List<PlayerStateDto> Players { get; set; }
        private List<CardDto> CommunityCards { get; set; }
        private int Pot { get; set; }
        private string CurrentTurnPlayerId { get; set; }
        private string Phase { get; set; }

        public GameStateEvent(List<PlayerStateDto> players, List<CardDto> communityCards, int pot, string currentTurnPlayerId, string phase)
        {
            this.Players = players;
            this.CommunityCards = communityCards;
            this.Pot = pot;
            this.CurrentTurnPlayerId = currentTurnPlayerId;
            this.Phase = phase;
        }
    }
}