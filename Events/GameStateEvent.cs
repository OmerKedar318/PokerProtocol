using Poker.Protocol.Abstractions;
using Poker.Protocol.DTOs;

namespace Poker.Protocol.Events;

public class GameStateEvent : BaseEvent
{
    // 1. Override the MsgType from the root NetworkMessage
    // This tells the serializer "I am a GameStateEvent"
    public override string MsgType => MessageTypes.GameStateEvent;

    // 2. Properties MUST be public for the JSON Serializer to work!
    public List<PlayerStateDto> Players { get; set; } = new();
    public List<CardDto> CommunityCards { get; set; } = new();
    public int Pot { get; set; }
    public string CurrentTurnPlayerId { get; set; } = string.Empty;
    public string Phase { get; set; } = string.Empty;

    // 3. Empty constructor is required for Deserialization on the Client
    public GameStateEvent() { }

    // 4. Cleaned up constructor for the Server to use
    public GameStateEvent(
        List<PlayerStateDto> players,
        List<CardDto> communityCards,
        int pot,
        string currentTurnPlayerId,
        string phase)
    {
        Players = players;
        CommunityCards = communityCards;
        Pot = pot;
        CurrentTurnPlayerId = currentTurnPlayerId;
        Phase = phase;
    }
}