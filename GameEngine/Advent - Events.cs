﻿using System;

namespace GameEngine
{
    /// <summary>
    /// Events generated by the game
    /// </summary>
    static partial class Advent
    {

        public static event EventHandler<Roomview> RoomView;

        /// <summary>
        /// Display the room view - items and description
        /// </summary>
        private static void SetRoomView()
        {
            RoomView?.Invoke(null, new Roomview(_RoomView, _RoomItems));
        }

        public static event EventHandler<GameOuput> GameMessages;

        /// <summary>
        /// Send a message out
        /// </summary>
        /// <param name="pMessage">Message to display</param>
        /// <param name="pClearOutput">Clear output before displaying message</param>
        private static void SendGameMessages(string pMessage, bool pClearOutput)
        {
            GameMessages?.Invoke(null, new GameOuput(pMessage, pClearOutput));
        }

        public class Roomview : EventArgs
        {
            public string View { get; private set; }
            public string Items { get; private set; }

            public Roomview(string pView, string pItems)
            {
                View = pView;
                Items = pItems;
            }
        }

        public class GameOuput : EventArgs
        {
            public string Message { get; private set; }
            public bool Refresh { get; private set; }

            public GameOuput(string pMessage, bool pRefresh)
            {
                Message = pMessage;
                Refresh = pRefresh;
            }
        }

    }
}
