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
    public class PlaceDetailWithPropertyList
    {
        [Key]
        public int PlaceId { get; set; }
        [DisplayName("مکان")]
        public required string PlaceName { get; set; }
        [DisplayName("توضیح مکان")]
        public string PlaceDescription { get; set; } = string.Empty;

        public List<Property>? PropertyList { get; set; }
    }
}
