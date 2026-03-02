namespace Poker.Protocol.DTOs
{
    public class GameStateDto
    {
        public List<PlayerStateDto> Players { get; set; }
        public List<CardDto> CommunityCards { get; set; }
        public int PotSize { get; set; }
        public int CurrentBet { get; set; }
        public string ActivePlayerId { get; set; }
        public GameStage Stage { get; set; } // Enum: PreFlop, Flop, etc.
    }
}