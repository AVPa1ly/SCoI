using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Entities
{
    public class GameGroup
    {
        public int GameGroupId { get; set; }
        public string GroupName { get; set; }

        /// <summary>
        /// Навигационное свойство один-ко-многим
        /// </summary>
        public List<Game> Games { get; set; }
    }
}
