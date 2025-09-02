using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMail.DataLayer.DTO
{
    public class UserLogin
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5,ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string UserName { get; set => field = value.ToLower(); }
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(8, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string Password { get; set; }
        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; } = false;
    }
}
