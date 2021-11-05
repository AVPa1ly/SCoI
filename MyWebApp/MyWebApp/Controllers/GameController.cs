using Microsoft.AspNetCore.Mvc;
using MyWebApp.Entities;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class GameController : Controller
    {
        List<Game> _games;
        List<GameGroup> _gameGroups;

        int _pageSize;

        public GameController()
        {
            _pageSize = 3;
            SetUpData();
        }
        
        public IActionResult Index(int pageNo=1)
        {
            return View(ListViewModel<Game>.GetModel(_games, pageNo, _pageSize));
        }

        /// <summary>
        /// Инициализация списка
        /// </summary>
        public void SetUpData()
        {
            _gameGroups = new List<GameGroup>
            {
                new GameGroup{GameGroupId = 1, GroupName = "Шутеры"},
                new GameGroup{GameGroupId = 2, GroupName = "Спортивные"},
                new GameGroup{GameGroupId = 3, GroupName = "Файтинги"},
                new GameGroup{GameGroupId = 4, GroupName = "Экшен-РПГ"},
                new GameGroup{GameGroupId = 5, GroupName = "Приключения"},
                new GameGroup{GameGroupId = 6, GroupName = "Прочие"},
            };

            _games = new List<Game>
            {
                new Game{GameId = 1, GameName = "FIFA 22", Description = "Задонать. Быстро. А то получишь по попе",
                    Cost = 5499, GameGroupId = 2, Image = "fifa.jpg"},
                new Game{GameId = 2, GameName = "Call of Duty: Modern Warfare (2019)", Description = "Русские проводят геноцид коренных урзыкстанцев",
                    Cost = 4999, GameGroupId = 1, Image = "codmw.jpg"},
                new Game{GameId = 3, GameName = "Cyberpunk 2077", Description = "Чапи-баги слайдшоу с Киану Ривзом в главной роли",
                    Cost = 3219, GameGroupId = 4, Image = "cyberpunk.jpg"},
                new Game{GameId = 4, GameName = "Detroit: Become Human", Description = "Мыльная опера про любовь, смерть и роботов",
                    Cost = 2149, GameGroupId = 5, Image = "detroit.jpg"},
                new Game{GameId = 5, GameName = "Grand Theft Auto 5", Description = "Три дурачка с пушками ищут НЛО в Лос-Сантосе",
                    Cost = 2849, GameGroupId = 1, Image = "gta.jpg"},
                new Game{GameId = 6, GameName = "Hades", Description = "Пошел как-то Петрович на прогулку в Ад...",
                    Cost = 1789, GameGroupId = 4, Image = "hades.jpg"},
                new Game{GameId = 7, GameName = "Hot Wheels Unleashed", Description = "Мало было пластмассок, теперь еще и на приставке",
                    Cost = 3219, GameGroupId = 6, Image = "hot-wheels.jpg"},
                new Game{GameId = 8, GameName = "Just Dance 2022", Description = "Танцуй, пока не кончится дождь",
                    Cost = 3999, GameGroupId = 6, Image = "just-dance.jpg"},
                new Game{GameId = 9, GameName = "Mortal Kombat X", Description = "Побей своего друга, рандомно протыкивая все кнопки геймпада",
                    Cost = 1429, GameGroupId = 3, Image = "mortal-kombat.jpg"},
                new Game{GameId = 10, GameName = "NBA 2k22", Description = "Это как FIFA, но про баскетбол",
                    Cost = 5499, GameGroupId = 2, Image = "nba.jpg"},
                new Game{GameId = 11, GameName = "NHL 22", Description = "Хоккейчик, мужчины походят на Овечкина",
                    Cost = 5499, GameGroupId = 2, Image = "nhl.jpg"},
                new Game{GameId = 12, GameName = "Rayman Legends", Description = "Два веселых гуся",
                    Cost = 1429, GameGroupId = 5, Image = "rayman.jpg"},
                new Game{GameId = 13, GameName = "Marvel's Spider Man", Description = "Does whatever a spider can",
                    Cost = 2849, GameGroupId = 4, Image = "spider-man.jpg"},
                new Game{GameId = 14, GameName = "Marvel's Spider Man: Miles Morales", Description = "Does whatever a black man can",
                    Cost = 4299, GameGroupId = 4, Image = "spider-man-miles.jpg"},
                new Game{GameId = 15, GameName = "Ghost of Tsushima", Description = "Злой монгола украла наш рис",
                    Cost = 4999, GameGroupId = 4, Image = "tsushima.jpg"},
                new Game{GameId = 16, GameName = "Assasin's Creed Valhalla", Description = "РПГ, притворяющееся Assasin's Creed-ом",
                    Cost = 4499, GameGroupId = 4, Image = "valhalla.jpg"},
                new Game{GameId = 17, GameName = "Watch Dogs: Legion", Description = "Обо всех и ни о чем",
                    Cost = 4499, GameGroupId = 4, Image = "watch-dogs.jpg"},
                new Game{GameId = 18, GameName = "The Witcher 3: Wild Hunt", Description = "Ламберт, Ламберт, хер моржовый, Ламберт, Ламберт, вредный...",
                    Cost = 2599, GameGroupId = 4, Image = "witcher.jpg"}
            };
        }
    }
}
