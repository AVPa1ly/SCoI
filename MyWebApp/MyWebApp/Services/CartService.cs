using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyWebApp.Entities;
using MyWebApp.Extensions;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWebApp.Services
{
    public class CartService: Cart
    {
        private string sessionKey = "cart";
        /// <summary>
        /// Объект сессии
        /// Не записывается в сессию вместе с CartService
        /// </summary>
        [JsonIgnore]
        ISession Session { get; set; }

        /// <summary>
        /// Получение объекта класса CartService
        /// </summary>
        /// <param name="sp">Объект IServiceProvider</param>
        /// <returns>Объект класса CartService, приведенный к типу Cart</returns>
        public static Cart GetCart(IServiceProvider sp)
        {
            // Получить объект сессии
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            // Получить CartService из сесии или создать новый для возможности тестирования
            var cart = session?.Get<CartService>("cart") ?? new CartService();
            cart.Session = session;
            return cart;
        }

        // Переопределение методов класса Cart для сохранения результатов в сессии
        public override void AddToCart(Game game)
        {
            base.AddToCart(game);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void ClearAll(int id)
        {
            base.ClearAll(id);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}
