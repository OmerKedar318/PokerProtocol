using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Serialization
{
    public static class MessageRegistry
    {
        private static readonly Dictionary<string, Type> _messageTypes;

        static MessageRegistry()
        {
            // Automatically find all classes that inherit from NetworkMessage
            _messageTypes = typeof(NetworkMessage).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(NetworkMessage)))
                .ToDictionary(t => t.Name, t => t);
        }

        public static Type GetTypeForMessage(string messageType)
        {
            return _messageTypes.TryGetValue(messageType, out var type) ? type : null;
        }
    }
}