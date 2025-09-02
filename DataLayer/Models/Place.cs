using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        [DisplayName("مکان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        [MinLength(5, ErrorMessage = "ورودی {0} کمتر از حد مجاز است")]
        public required string PlaceName { get; set; }
        [DisplayName("توضیح مکان")]
        [MaxLength(550, ErrorMessage = "ورودی {0} بیش از حد مجاز است")]
        public string PlaceDescription { get; set; } = string.Empty;

        public Place() { }
        public List<Property>? Properties { get; set; }
    }
}
