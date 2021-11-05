using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Image { get; set; } // Имя файла изображения

        // Навигационные свойства
        /// <summary>
        /// Группы игровых жанров (пр., Шутеры, Спортивные и т.д.)
        /// </summary>
        public int GameGroupId { get; set; }
        public GameGroup Group { get; set; }
    }
}
