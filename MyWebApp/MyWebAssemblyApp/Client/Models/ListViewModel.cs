using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWebAssemblyApp.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("gameId")]
        public int GameId { get; set; } // ID игры
        [JsonPropertyName("gameName")]
        public string GameName { get; set; } // Название игры
    }
}
