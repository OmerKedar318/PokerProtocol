using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events
{
    public class GameStateEvent : NetworkMessage, IEvent
    {
        public List<PlayerStateDto> Players { get; set; }
        public List<CardDto> CommunityCards { get; set; }
        public int Pot { get; set; }
        public string CurrentTurnPlayerId { get; set; }
        public string Phase { get; set; }

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