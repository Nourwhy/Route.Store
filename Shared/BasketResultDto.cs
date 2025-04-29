using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BasketResultDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        [Range(minimum: 0, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(minimum: 1, maximum: 99)]
        public int Quantity { get; set; }
    }
}
