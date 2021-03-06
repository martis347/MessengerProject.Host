﻿using System;
using System.Collections.Generic;
using Messenger.Displays;

namespace Messenger
{
    public class Server
    {
        private readonly Dictionary<string, ChatRoom> _chatRooms = new Dictionary<string, ChatRoom>();
        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>();

        public RequestStatus CreateRoom(string roomName, ChatUser user)
        {
            try
            {
                _chatRooms.Add(roomName, new ChatRoom(roomName, user));
                return RequestStatus.Success;
            }
            catch (Exception)
            {
                return RequestStatus.RoomAlreadyExists;
            }
        }

        public RequestStatus RemoveRoom(string roomName)
        {
            try
            {
                _chatRooms.Remove(roomName);
                return RequestStatus.Success;
            }
            catch (Exception)
            {
                return RequestStatus.RoomNotFound;
            }
        }

        public RequestStatus CreateUser(string username)
        {
            var user = new ChatUser(username,new UserDisplay("NONE",username));
            try
            {
                _users.Add(username,user);
                return RequestStatus.Success;
            }
            catch (Exception)
            {
                return RequestStatus.UserAlreadyExists;
            }
        }

        public ChatRoom Room(string name)
        {
            try
            {
                ChatRoom room = _chatRooms[name];
                return room;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ChatUser User(string name)
        {
            try
            {
                ChatUser user = _users[name];
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public RequestStatus RemoveUser(string username)
        {
            try
            {
                _users.Remove(username);
                return RequestStatus.Success;
            }
            catch (Exception)
            {
                return RequestStatus.UserNotFound;
            }
        }
    }
}