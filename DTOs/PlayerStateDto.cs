namespace Poker.Protocol.DTOs
{
    public class PlayerStateDto
    {
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public int Chips { get; set; }
        public int CurrentBet { get; set; }
        public bool HasFolded { get; set; }

        public PlayerStateDto(string PlayerId, string Name, int Chips, int CurrentBet)
        {
            this.PlayerId = PlayerId;
            this.Name = Name;
            this.Chips = Chips;
            this.CurrentBet = CurrentBet;
            // If paid to join game, change HasFolded to false.
        }
    }
}