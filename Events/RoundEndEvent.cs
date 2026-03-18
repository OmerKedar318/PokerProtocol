using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;
using System.Collections.Generic;

namespace Poker.Protocol.Events;

public class RoundEndEvent : BaseEvent
{
    // Override the abstract MsgType from the root NetworkMessage
    public override string MsgType => MessageType.RoundEndEvent;

    // Properties must be public for the JSON Serializer to work
    public List<WinnerDto> Winners { get; set; } = new();

    // Key: PlayerId, Value: Their 2 hole cards (Showdown)
    public Dictionary<string, List<CardDto>> RevealedHands { get; set; } = new();

    public List<CardDto> FinalCommunityCards { get; set; } = new();

    public int TotalPot { get; set; }

    // Required for the JSON Deserializer
    public RoundEndEvent() { }

    public RoundEndEvent(
        List<WinnerDto> winners,
        Dictionary<string, List<CardDto>> revealHands,
        List<CardDto> finalCommunityCards,
        int totalPot)
    {
        Winners = winners;
        RevealedHands = revealHands;
        FinalCommunityCards = finalCommunityCards;
        TotalPot = totalPot;
    }
}