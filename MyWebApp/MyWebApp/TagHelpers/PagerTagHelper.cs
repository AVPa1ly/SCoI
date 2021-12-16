using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.TagHelpers
{
    public class PagerTagHelper: TagHelper
    {
        LinkGenerator _linkGenerator;


        // Номер текущей страницы
        public int PageCurrent { get; set; }
        // Общее количество страниц
        public int PageTotal { get; set; }
        // Дополнительный css класс пейджера
        public string PagerClass { get; set; }
        // Имя action
        public string Action { get; set; }
        // Имя контроллера
        public string Controller { get; set; }
        public int? GroupID { get; set; }

        public PagerTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Контейнер разметки пейджера
            output.TagName = "nav";

            // Пейджер
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);

            for (int i = 1; i < PageTotal; i++)
            {
                var url = _linkGenerator.GetPathByAction(Action, Controller, 
                    new 
                    { 
                        pageNo = i,
                        group = GroupID == 0? null: GroupID
                    });
                // Получение разметки одной кнопки пейджера
                var item = GetPagerItem(url: url, text: i.ToString(), active: i == PageCurrent, disabled: i == PageCurrent);
                // Добавить кнопку в разметку пейджера
                ulTag.InnerHtml.AppendHtml(item);
            }
            // Добавить пейджер в контейнер
            output.Content.AppendHtml(ulTag);
        }

        /// <summary>
        /// Генерирует разметку одной кнопки пейджера
        /// </summary>
        /// <param name="url">адрес</param>
        /// <param name="text">текст кнопки пейджера</param>
        /// <param name="active">признак текущей страницы</param>
        /// <param name="disabled">запретить доступ к кнопке</param>
        /// <returns>объект класса TagBuilder</returns>
        private TagBuilder GetPagerItem(string url, string text, bool active = false, bool disabled = false)
        {
            // Создать тег <li>
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active? "active": "");
            // liTag.AddCssClass(disabled ? "active" : "");

            // Создать тег <a>
            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);

            // Добавить тег <a> внутрь <li>
            liTag.InnerHtml.AppendHtml(aTag);

            return liTag;
        }
    }
}
