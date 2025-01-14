using XlgamesBackend.Models.GameServerDatas;

namespace XlgamesBackend.Models.GameServers
{
    public class GameServerLink : GameServer
    {
        public ICollection<GameServerDataPrimaryModel> GameServerDataPrimaryModels { get; set; } 
            = new List<GameServerDataPrimaryModel>();
    }
}
