﻿using MasterServerToolkit.Networking;
using System;

namespace MasterServerToolkit.MasterServer
{
    public interface ILobby
    {
        int Id { get; }
        string Type { get; set; }
        string GameIp { get; }
        int GamePort { get; }
        int MaxPlayers { get; }
        string Name { get; set; }
        int PlayerCount { get; }

        event Action<ILobby> OnDestroyedEvent;

        MstProperties GetPublicProperties(IPeer peer);

        bool AddPlayer(LobbyUserPeerExtension playerExt, out string error);
        void RemovePlayer(LobbyUserPeerExtension playerExt);

        bool SetProperty(LobbyUserPeerExtension setter, string key, string value);
        bool SetProperty(string key, string value);

        LobbyMember GetMemberByExtension(LobbyUserPeerExtension playerExt);
        LobbyMember GetMemberByUsername(string username);
        LobbyMember GetMemberByPeerId(int peerId);

        void SetReadyState(LobbyMember member, bool state);

        bool SetPlayerProperty(LobbyMember player, string key, string value);
        bool TryJoinTeam(string teamName, LobbyMember player);

        LobbyDataPacket GenerateLobbyData(LobbyUserPeerExtension user);
        LobbyDataPacket GenerateLobbyData();
        bool StartGameManually(LobbyUserPeerExtension user);

        void ChatMessageHandler(LobbyMember member, IIncommingMessage message);
        void GameAccessRequestHandler(IIncommingMessage message);
    }
}