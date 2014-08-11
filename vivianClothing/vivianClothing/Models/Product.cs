using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace vivianClothing.Models
{
    [DisplayName("商品資訊")]
    [DisplayColumn ("Name")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("商品類別")]
        [Required]
        public virtual ProductCategory ProductCategory { get; set; }

        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MaxLength(60, ErrorMessage = "商品名稱不可以超過60個字")]
        public string Name { get; set; }

        [DisplayName("商品簡介")]
        [Required(ErrorMessage="請輸入商品簡介")]
        [MaxLength(250,ErrorMessage="不可超過250字")]
        public string Description{get;set;}

        [DisplayName("商品顏色")]
        [Required(ErrorMessage="請選擇商品顏色")]
        public Color Color{get;set;}

        [DisplayName("商品售價")]
        [Required(ErrorMessage = "請輸入商品售價")]
        [Range(99, 10000, ErrorMessage = "商品售價必須介於99 ~ 10,000 之間")]
        public int Price { get; set; }

        [DisplayName("上架時間")]
        [Description ("如果沒有設定時間代表不上架")]
        public DateTime? PublishOn { get; set; }

       // public virtual ProductCategory ProductCategory { get; set; }

    }
}