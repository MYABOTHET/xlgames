namespace XlgamesBackend.Models.GameServersBases
{
    public class GameServerCard : Base
    {
        public ICollection<GameServerDataBase> GameServerDataBases { get; set; } = new List<GameServerDataBase>();
    }
}
