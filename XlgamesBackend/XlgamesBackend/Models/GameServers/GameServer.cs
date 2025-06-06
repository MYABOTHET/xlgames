﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using XlgamesBackend.Models.GameServerDatas;

namespace XlgamesBackend.Models.GameServers
{
    // Игровой сервер
    [Index(nameof(Name), IsUnique = true)]
    public class GameServer : GameServerBase
    {
        public bool DedicatedDescription { get; set; }
        public string CPU { get; set; } = "...";
        public string RAM { get; set; } = "...";
        public string Disk { get; set; } = "...";
        public string Slots { get; set; } = "...";
        public string Link { get; set; } = "...";
        public bool ControlPanel { get; set; }
        public bool FTP { get; set; }
        public string Execute { get; set; } = "(() => {})()";
        [JsonIgnore]
        public ICollection<GameServerData> GameServerDatas { get; } = new List<GameServerData>();
    }
}
