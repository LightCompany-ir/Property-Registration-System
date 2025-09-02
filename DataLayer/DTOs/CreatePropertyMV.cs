using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class CreatePropertyMV
    {
        [DisplayName(" نام دارایی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string PropertyName { get; set; }
        [DisplayName(" برند دارایی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string PropertyBrand { get; set; }
        [DisplayName(" رنگ دارایی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string PropertyColor { get; set; } = "نامشخص";
        [DisplayName(" توضیحات دارایی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string PropertyDescription { get; set; } = "بدون توضیح";
        [DisplayName(" مستقر شده در ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PlaceId { get; set; }
        [DisplayName(" ثبت شده توسط ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CreatedByUser { get; set; }
    }
}
/* PropertyName,PropertyBrand,PropertyColor,PropertyDescription,PlaceId,CreatedByUser */