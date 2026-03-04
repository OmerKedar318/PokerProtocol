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

//omer add this
Host will send this request to start the round, it will be sent after all players have joined and are ready, and before the server sends the PrivateCardsEvent to deal the hole cards.
StartRoundRequest.cs:
{
  "MessageType": "StartRoundRequest",
  "Timestamp": 1709574005,
  "RequestId": "req_8820"
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

JoinTableResponse.cs: Confirms if a player successfully joined a table and provides their assigned seat ID, and returns a flags IsHost so user will know if he is the host of the table.

{
  "MessageType": "JoinTableResponse",
  "Timestamp": 1709574001,
  "RequestId": "req_8821",
  "Success": true,
  "ErrorMessage": null,
  "AssignedSeatId": "Seat_4"
  "IsHost": true"
}

GenericResponse.cs: A standard acknowledgement for actions, containing a Success boolean and an ErrorMessage if an action (like a bet) was invalid.

{
  "MessageType": "GenericResponse",
  "Timestamp": 1709574051,
  "RequestId": "req_8822",
  "Success": false,
  "ErrorMessage": "Insufficient chips for this bet."
}


To visualize how a hand of poker moves through your system, here is the chronological workflow using the messages you've built. This sequence ensures that the server remains the "Source of Truth" while the clients stay synchronized.


Phase 1: Joining & Initialization

Before the cards are dealt, the players must be seated and synced.

JoinTableRequest: The client sends player details and preferred table.

JoinTableResponse: The server validates the seat and returns a success message with the AssignedSeatId.

GameStateEvent: The server broadcasts the updated table state to all players so everyone sees the new person sitting down.


Phase 2: The Deal (Pre-Flop)

The server starts the hand logic.

PrivateCardsEvent: The server sends individual messages to each player at the table.

Note: Player A only receives Player A's cards; Player B only receives Player B's cards.

GameStateEvent: The server broadcasts that the round has started, identifies the Dealer, Small Blind, and Big Blind, and sets the ActivePlayerId to the person "Under the Gun."


Phase 3: The Betting Rounds

This phase repeats for the Pre-flop, Flop, Turn, and River.

GameStateEvent: The server notifies everyone whose turn it is.

BetRequest / RaiseRequest / FoldRequest: The active player sends their "Intent" to the server.

GenericResponse: The server validates the move (e.g., checking if they have enough chips) and sends a confirmation to that player.

GameStateEvent: The server broadcasts the move to the whole table, updating the pot size and moving the ActivePlayerId to the next person.


Phase 4: The Showdown & Cleanup

Once all betting is finished after the River, or if a player goes all-in and is called.

RoundEndEvent: The server calculates the winner(s) and sends this final packet.

Winners: List of who gets the chips and their hand rank (e.g., "Straight").

RevealedHands: The server now shares the hole cards of everyone who didn't fold so the UI can flip them over.

GameStateEvent: After a short delay (for the "Win" animation), the server resets the board and starts the next hand.
