# PokerProtocol
This documentation provides a technical overview of the Poker.Protocol library as developed so far. The protocol is designed as a C# class library that serves as a shared "contract" between the game server and the client.

Architectural Overview

The protocol follows a Server-Authoritative model using a typed message system. It is structured to handle real-time, bidirectional communication, typically intended for use over WebSockets.

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

3. Messaging Protocol (Requests & Events)

The protocol distinguishes between actions initiated by the player and updates pushed by the server.

Client Requests:

JoinTableRequest.cs: Used by a player to request a seat at a specific table.

BetRequest.cs / RaiseRequest.cs / FoldRequest.cs: Standard poker actions sent to the server for validation.

Server Events:

PrivateCardsEvent.cs: A secure message sent only to a specific player containing their "hole" cards.

RoundEndEvent.cs: A detailed summary sent at the end of a hand. It includes a WinnerDto list (supporting split pots), the HandRankName (e.g., "Full House"), and a dictionary of RevealedHands for the "Showdown".

4. Serialization & Registry

This layer handles the translation of C# objects into JSON strings for network transport.

MessageRegistry.cs: Uses Reflection to automatically map incoming JSON "MessageType" strings to the correct C# class types.

MessageDeserializer.cs: The engine that converts raw JSON into actionable NetworkMessage objects using the Registry.

5. Responses

JoinTableResponse.cs: Confirms if a player successfully joined a table and provides their assigned seat ID.

GenericResponse.cs: A standard acknowledgement for actions, containing a Success boolean and an ErrorMessage if an action (like a bet) was invalid.
