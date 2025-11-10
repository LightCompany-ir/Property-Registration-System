using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        [DisplayName(" نام کالا ")]
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
        [DisplayName(" ثبت شده توسط ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CreatedByUser { get; set; }
        [DisplayName(" بروز شده توسط ")]
        public int? UpdatedByUser { get; set; } = null;
        [DisplayName(" حذف شده توسط ")]
        public int? DeletedByUser { get; set; } = null;
        [DisplayName(" تاریخ ایجاد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DisplayName(" تاریخ بروزرسانی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Property() { }
        public virtual Place Place { get; set; }
    }
}
/*PropertyId,PropertyName,OldPropertyNumber,NewPropertyNumber,PropertyDescription,PlaceId,CreatedByUser,UpdatedByUser,DeletedByUser,CreatedDate,UpdatedDate*/