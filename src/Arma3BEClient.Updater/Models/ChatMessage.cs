﻿using System;

namespace Arma3BEClient.Updater.Models
{
    public class ChatMessage
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public enum MessageType { Unknown, Side, Direct, Vehicle, Global, Group, Command, RCon }


        public MessageType Type
        {
            get
            {

                if (Message.StartsWith("(Side)")) return MessageType.Side;
                if (Message.StartsWith("(Vehicle)")) return MessageType.Vehicle;
                if (Message.StartsWith("(Global)")) return MessageType.Global;
                if (Message.StartsWith("(Group)")) return MessageType.Group;
                if (Message.StartsWith("(Command)")) return MessageType.Command;
                if (Message.StartsWith("(Direct)")) return MessageType.Direct;
                if (Message.StartsWith("RCon") &&
                    !Message.Contains("logged in") && !Message.Contains("Connection Lost!")) return MessageType.RCon;

                return MessageType.Unknown;
            }
        }
    }
}