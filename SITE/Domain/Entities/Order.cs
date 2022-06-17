using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Domain.Entities
{
    public class Order : EntityBase
    {
        [Required(ErrorMessage = "Заполните вашу контактную почту")]
        [Display(Name = "Почта")]
        public override string Post { get; set; }

        [Required(ErrorMessage = "Опишите ваш запрос")]
        [Display(Name = "Описание вашего запроса")]
        public override string OrderText { get; set; }
    }
}
