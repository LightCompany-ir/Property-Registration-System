using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class AdminUser
    {
        [Key]
        public int AdminUserId { get; set; }
        [DisplayName("نام کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string FullName { get; set; }
        [Display(Name = " نام کاربری ")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "مقدار {0} بیش از حد مجاز است")]
        [MinLength(10, ErrorMessage = "مقدار {0} کمتر از حد مجاز است")]
        public required string UserName { get; set; }
        [Display(Name = " رمز عبور ")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "مقدار {0} بیش از حد مجاز است")]
        [MinLength(8, ErrorMessage = "مقدار {0} کمتر از حد مجاز است")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Display(Name = " شماره همراه ")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "مقدار {0} بیش از حد مجاز است")]
        [MinLength(11, ErrorMessage = "مقدار {0} کمتر از حد مجاز است")]
        public required string Phone { get; set; }
        [Display(Name = " تاریخ ثبت نام ")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        [Display(Name = " تصویر کاربر ")]
        public string UserImage { get; set; } = "Default.png";
        [Display(Name = "کاربر فعال")]
        public bool IsActive { get; set; } = false;
    }
}
