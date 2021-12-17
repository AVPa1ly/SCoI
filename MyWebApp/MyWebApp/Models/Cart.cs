using MyWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        /// <summary>
        /// Стоимость товаров
        /// </summary>
        public int Cost
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Game.Cost);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="game">Добавляемый объект</param>
        public virtual void AddToCart (Game game)
        {
            // Если объект есть в корзине, то увеличить количество
            if (Items.ContainsKey(game.GameId))
            {
                Items[game.GameId].Quantity++;
            }
            else
            {
                Items.Add(game.GameId, new CartItem
                {
                    Game = game, Quantity = 1
                });
            }
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll(int id)
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}
