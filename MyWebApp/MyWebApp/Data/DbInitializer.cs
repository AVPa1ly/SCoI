using Microsoft.AspNetCore.Identity;
using MyWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            //Create DB if not created yet
            context.Database.EnsureCreated();

            //Check roles existance
            if (!context.Roles.Any())
            {
                var roleadmin = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "admin"
                };
                //Create Admin role
                await roleManager.CreateAsync(roleadmin);
            }

            if (!context.Users.Any())
            {
                //Create user "user@mail.ru"
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                //Create user "admin@mail.ru"
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                //Give Admin role to "admin@mail.ru" user
                admin = await userManager.FindByNameAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            // Проверка наличия групп объектов
            if (!context.GameGroups.Any())
            {
                context.GameGroups.AddRange(
                    new List<GameGroup>
                    {
                        new GameGroup{GroupName = "Шутеры"},
                        new GameGroup{GroupName = "Спортивные"},
                        new GameGroup{GroupName = "Файтинги"},
                        new GameGroup{GroupName = "Экшен-РПГ"},
                        new GameGroup{GroupName = "Приключения"},
                        new GameGroup{GroupName = "Прочие"},
                    });
                await context.SaveChangesAsync();
            }

            // Проверка наличия объектов
            if (!context.Games.Any())
            {
                context.Games.AddRange(
                    new List<Game>
                    {
                        new Game{GameName = "FIFA 22", Description = "Задонать. Быстро. А то получишь по попе",
                            Cost = 5499, GameGroupId = 2, Image = "fifa.jpg"},
                        new Game{GameName = "Call of Duty: Modern Warfare (2019)", Description = "Русские проводят геноцид коренных урзыкстанцев",
                            Cost = 4999, GameGroupId = 1, Image = "codmw.jpg"},
                        new Game{GameName = "Cyberpunk 2077", Description = "Чапи-баги слайдшоу с Киану Ривзом в главной роли",
                            Cost = 3219, GameGroupId = 4, Image = "cyberpunk.jpg"},
                        new Game{GameName = "Detroit: Become Human", Description = "Мыльная опера про любовь, смерть и роботов",
                            Cost = 2149, GameGroupId = 5, Image = "detroit.jpg"},
                        new Game{GameName = "Grand Theft Auto 5", Description = "Три дурачка с пушками ищут НЛО в Лос-Сантосе",
                            Cost = 2849, GameGroupId = 1, Image = "gta.jpg"},
                        new Game{GameName = "Hades", Description = "Пошел как-то Петрович на прогулку в Ад...",
                            Cost = 1789, GameGroupId = 4, Image = "hades.jpg"},
                        new Game{GameName = "Hot Wheels Unleashed", Description = "Мало было пластмассок, теперь еще и на приставке",
                            Cost = 3219, GameGroupId = 6, Image = "hot-wheels.jpg"},
                        new Game{GameName = "Just Dance 2022", Description = "Танцуй, пока не кончится дождь",
                            Cost = 3999, GameGroupId = 6, Image = "just-dance.jpg"},
                        new Game{GameName = "Mortal Kombat X", Description = "Побей своего друга, рандомно протыкивая все кнопки геймпада",
                            Cost = 1429, GameGroupId = 3, Image = "mortal-kombat.jpg"},
                        new Game{GameName = "NBA 2k22", Description = "Это как FIFA, но про баскетбол",
                            Cost = 5499, GameGroupId = 2, Image = "nba.jpg"},
                        new Game{GameName = "NHL 22", Description = "Хоккейчик, мужчины походят на Овечкина",
                            Cost = 5499, GameGroupId = 2, Image = "nhl.jpg"},
                        new Game{GameName = "Rayman Legends", Description = "Два веселых гуся",
                            Cost = 1429, GameGroupId = 5, Image = "rayman.jpg"},
                        new Game{GameName = "Marvel's Spider Man", Description = "Does whatever a spider can",
                            Cost = 2849, GameGroupId = 4, Image = "spider-man.jpg"},
                        new Game{GameName = "Marvel's Spider Man: Miles Morales", Description = "Does whatever a black man can",
                            Cost = 4299, GameGroupId = 4, Image = "spider-man-miles.jpg"},
                        new Game{GameName = "Ghost of Tsushima", Description = "Злой монгола украла наш рис",
                            Cost = 4999, GameGroupId = 4, Image = "tsushima.jpg"},
                        new Game{GameName = "Assasin's Creed Valhalla", Description = "РПГ, притворяющееся Assasin's Creed-ом",
                            Cost = 4499, GameGroupId = 4, Image = "valhalla.jpg"},
                        new Game{GameName = "Watch Dogs: Legion", Description = "Обо всех и ни о чем",
                            Cost = 4499, GameGroupId = 4, Image = "watch-dogs.jpg"},
                        new Game{GameName = "The Witcher 3: Wild Hunt", Description = "Ламберт, Ламберт, хер моржовый, Ламберт, Ламберт, вредный...",
                            Cost = 2599, GameGroupId = 4, Image = "witcher.jpg"}
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
