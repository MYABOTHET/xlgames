using XlgamesBackend.Models.GameServerDatas;

namespace XlgamesBackend.Models.GameServers
{
    public class GameServerCard : GameServerBase
    {
        public ICollection<GameServerDataModel> GameServerDataModels { get; set; } = new List<GameServerDataModel>();
    }
}
