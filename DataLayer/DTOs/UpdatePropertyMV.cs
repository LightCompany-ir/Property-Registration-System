using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class UpdatePropertyMV
    {
        [Key]
        public int PropertyId { get; set; }
        [DisplayName(" نام دارایی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(3, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string PropertyName { get; set; }
        [DisplayName("شماره اموال قدیم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(3, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string OldPropertyNumber { get; set; }
        [DisplayName("شماره اموال جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(3, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string NewPropertyNumber { get; set; } = "نامشخص";
        [DisplayName(" توضیحات دارایی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        public required string PropertyDescription { get; set; } = "بدون توضیح";
        [DisplayName(" مستقر شده در ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PlaceId { get; set; }
        [DisplayName(" بروز شده توسط ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UpdatedByUser { get; set; }
    }
}
/*PropertyId,PropertyName,PropertyBrand,PropertyColor,PropertyDescription,PlaceId,UpdatedByUser*/