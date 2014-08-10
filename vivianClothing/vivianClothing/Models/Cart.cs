using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vivianClothing.Models
{
    public class Cart
    {
        [DisplayName("選購商品")]
        [Required]
        public Product Product { get; set; }

        [DisplayName("選購數量")]
        [Required]
        public int Amount { get; set; }
    }
}