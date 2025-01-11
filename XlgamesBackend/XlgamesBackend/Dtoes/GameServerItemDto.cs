using XlgamesBackend.Models;

namespace XlgamesBackend.Dtoes
{
    public class GameServerItemDto : BaseGameServerItem
    {
        public ICollection<Preset> Presets { get; set; } = new List<Preset>();
    }
}
