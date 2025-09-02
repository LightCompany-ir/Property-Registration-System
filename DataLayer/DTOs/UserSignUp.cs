using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class UserSignUp
    {
        [DisplayName("نام کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string FullName { get; set; }
        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "مقدار شماره همراه باید 11 رقمی باشد")]
        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "قالب {0} اشتباه است")]
        public required string Phone { get; set; }
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string UserName { get => field.ToLower(); set => field = value.ToLower(); }
        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(8, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [DisplayName("تکرار کلمه عبور")]
        [Compare("Password",ErrorMessage = "تکرار رمز عبور باید برابر با رمز عبور باشد")]
        public required string RePassword { get; set; }
    }
}
