using Microsoft.EntityFrameworkCore;

namespace XlgamesBackend.Models
{
    // Игровой сервер
    [Index(nameof(Name), IsUnique = true)]
    public class GameServerItem : BaseGameServerItem
    {
        public string CPU { get; set; } = "...";
        public string RAM { get; set; } = "...";
        public string Disk { get; set; } = "...";
        public string Slots { get; set; } = "...";
        public ICollection<GameServerData> GameServerDatas { get; } = new List<GameServerData>();
    }
}
