using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;
using System.Collections.Generic;

namespace Poker.Protocol.Events
{
    public class RoundEndEvent : NetworkMessage, IEvent
    {
        private List<WinnerDto> Winners { get; set; } = new List<WinnerDto>();
        // Key: PlayerId, Value: Their 2 cards
        private Dictionary<string, List<CardDto>> RevealedHands { get; set; } = new Dictionary<string, List<CardDto>>();
        private List<CardDto> FinalCommunityCards { get; set; } = new List<CardDto>();
        private int TotalPot { get; set; }

        public RoundEndEvent(List<WinnerDto> winners, Dictionary<string, List<CardDto>> revealHands, List<CardDto> finalCommunityCards, int totalPot) 
        {
            this.Winners = winners;
            this.RevealedHands = revealHands;
            this.FinalCommunityCards = finalCommunityCards;
            this.TotalPot = totalPot;
        }
    }
}