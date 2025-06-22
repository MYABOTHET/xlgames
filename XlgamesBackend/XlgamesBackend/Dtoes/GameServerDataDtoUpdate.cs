using XlgamesBackend.Models;

namespace XlgamesBackend.Dtoes
{
    public class GameServerDataDtoUpdate : GameServerDataDto
    {
        public int Id { get; set; }

        public int GameServerId { get; set; }

        public int LanguageId { get; set; }
    }
}
