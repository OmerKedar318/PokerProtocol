# PokerProtocol

The protocol follows a Server-Authoritative model using a typed message system. It is structured to handle real-time, bidirectional communication, intended for use over WebSockets.

1. Core Abstractions

These files define the base behavior for every message sent over the network.

NetworkMessage.cs: The base class for all communication. It includes a MessageType string (derived from the class name) and a Timestamp to ensure messages can be ordered and identified upon arrival.

IRequest.cs & IResponse.cs: Interfaces used for two-way communication. Requests include a RequestId so the client can match a server's response to a specific action it took.

IEvent.cs: A marker interface for server-pushed updates (e.g., a new card being dealt) that do not require a direct response from the client.

2. Data Transfer Objects (DTOs)

These are "dumb" data containers used to represent the state of the game without containing business logic.

CardDto.cs: Represents a playing card using integers for efficiency: Suit (0–3) and Rank (2–14, where 14 is Ace).

PlayerStateDto.cs: Contains information about a player, such as their ID, name, current chip stack, and status (e.g., Folded, All-In).

GameStateDto.cs: The master object representing the table. It includes the list of players, the community cards (Flop/Turn/River), the current pot size, and identifies whose turn it is.

| Object | Purpose | Key Properties |
|--------|---------|----------------|
| **CardDto** | Represents a single playing card. | `Suit` (0-3: Spades, Hearts, Diamonds, Clubs)<br>`Rank` (2-14, where 14 = Ace) |
| **PlayerStateDto** | The current status of a specific player at the table. | `PlayerId`<br>`Name`<br>`Chips`<br>`IsDealer`<br>`CurrentBet`<br>`Status` |
| **GameStateDto** | A full snapshot of the table's current state. | `Players` (List\<PlayerStateDto\>)<br>`CommunityCards` (List\<CardDto\>)<br>`PotSize`<br>`ActivePlayerId`<br>`Stage` |
| **WinnerDto** | Details regarding a hand winner, used during showdowns. | `PlayerId`<br>`AmountWon`<br>`HandRankName` (e.g., "Full House")<br>`WinningHand` (List\<CardDto\>) |

3. Messaging Protocol (Requests & Events)

The protocol distinguishes between actions initiated by the player and updates pushed by the server.

Client Requests:

JoinTableRequest.cs: Used by a player to request a seat at a specific table.

{
  "MessageType": "JoinTableRequest",
  "Timestamp": 1709574000,
  "RequestId": "req_8821",
  "PlayerName": "Omer",
  "TableId": "Vegas_High_Stakes"
}

BetRequest.cs:

{
  "MessageType": "BetRequest",
  "Timestamp": 1709574050,
  "RequestId": "req_8822",
  "Amount": 500
}

RaiseRequest.cs:

{
  "MessageType": "RaiseRequest",
  "Timestamp": 1709574310,
  "RequestId": "req_8824",
  "Amount": 1000
}

FoldRequest.cs:

{
  "MessageType": "FoldRequest",
  "Timestamp": 1709574300,
  "RequestId": "req_8823"
}

Server Events:

PrivateCardsEvent.cs: A secure message sent only to a specific player containing their "hole" cards.

{
  "MessageType": "PrivateCardsEvent",
  "Timestamp": 1709574100,
  "Cards": [
    { "Suit": 1, "Rank": 14 },
    { "Suit": 1, "Rank": 13 }
  ]
}

GameStateEvent: Broadcast to everyone to update the table UI.

{
  "MessageType": "GameStateEvent",
  "Timestamp": 1709574110,
  "GameState": {
    "Players": [...],
    "CommunityCards": [
      { "Suit": 0, "Rank": 10 },
      { "Suit": 2, "Rank": 10 },
      { "Suit": 3, "Rank": 2 }
    ],
    "PotSize": 1200,
    "ActivePlayerId": "player_abc",
    "Stage": 1
  }
}

RoundEndEvent.cs: A detailed summary sent at the end of a round. It includes a WinnerDto list (supporting split pots), the HandRankName (e.g., "Full House"), and a dictionary of RevealedHands for the "Showdown".

{
  "MessageType": "RoundEndEvent",
  "Timestamp": 1709574200,
  "TotalPot": 3000,
  "Winners": [
    {
      "PlayerId": "Omer",
      "AmountWon": 3000,
      "HandRankName": "Full House",
      "WinningHand": [...]
    }
  ],
  "RevealedHands": {
    "Omer": [...],
    "Friend": [...]
  }
}

4. Serialization & Registry

This layer handles the translation of C# objects into JSON strings for network transport.

MessageRegistry.cs: Uses Reflection to automatically map incoming JSON "MessageType" strings to the correct C# class types.

MessageDeserializer.cs: The engine that converts raw JSON into actionable NetworkMessage objects using the Registry.

5. Responses

JoinTableResponse.cs: Confirms if a player successfully joined a table and provides their assigned seat ID.

{
  "MessageType": "JoinTableResponse",
  "Timestamp": 1709574001,
  "RequestId": "req_8821",
  "Success": true,
  "ErrorMessage": null,
  "AssignedSeatId": "Seat_4"
}

GenericResponse.cs: A standard acknowledgement for actions, containing a Success boolean and an ErrorMessage if an action (like a bet) was invalid.

{
  "MessageType": "GenericResponse",
  "Timestamp": 1709574051,
  "RequestId": "req_8822",
  "Success": false,
  "ErrorMessage": "Insufficient chips for this bet."
}
