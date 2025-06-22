using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using XlgamesBackend.Dtoes;
using XlgamesBackend.Models.GameServers;

namespace XlgamesBackend.Models.GameServerDatas
{
    public class GameServerData : GameServerDataDto
    {
        public int Id { get; set; }

        public int GameServerId { get; set; }
        [JsonIgnore]
        public GameServer GameServer { get; set; } = default!;

        public int LanguageId { get; set; }
        [JsonIgnore]
        public Language Language { get; set; } = default!;
    }
}
