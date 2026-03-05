namespace Poker.Protocol.DTOs
{
    public class PlayerStateDto
    {
        private string PlayerId { get; set; }
        private string Name { get; set; }
        private int Chips { get; set; }
        private int CurrentBet { get; set; }
        private bool HasFolded { get; set; }

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