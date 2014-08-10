using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vivianClothing.Models
{
    [DisplayName("商品類別")]
    [DisplayColumn("name")]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("商品類別名稱")]
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MaxLength(20, ErrorMessage = "不可超過20個字")]
        public string Name { get; set; }

    }
}