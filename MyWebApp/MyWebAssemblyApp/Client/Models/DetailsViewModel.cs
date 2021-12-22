using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWebAssemblyApp.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("gameName")]
        public string GameName { get; set; } // Название игры
        [JsonPropertyName("description")]
        public string Description { get; set; } // Описание игры
        [JsonPropertyName("cost")]
        public int Cost { get; set; } // Стоимость экземпляра игры
        [JsonPropertyName("image")]
        public string Image { get; set; } // Имя файла изображения
    }
}
