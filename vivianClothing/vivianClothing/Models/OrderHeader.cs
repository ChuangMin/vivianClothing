using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vivianClothing.Models
{
    [DisplayName("訂購主檔")]
    [DisplayColumn("DispalyName")]
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("訂購會員")]
        [Required]
        public virtual Member Member { get; set; }

        [DisplayName("收件人姓名")]
        [Required(ErrorMessage = "請輸入收件人姓名")]
        [Description("訂購的會員不一定是收到商品的人")]
        [MaxLength(40, ErrorMessage = "收件人姓名不能超過40個字")]
        public string ContactName { get; set; }

        [DisplayName("連絡電話")]
        [Required(ErrorMessage = "請輸入您的連絡電話，例如+886-2-23222480#6342")]
        [Description("訂購的會員不一定是收到商品的人")]
        [MaxLength(25, ErrorMessage = "電話號碼不能超過25個字")]
        public string ContactPhoneNo { get; set; }

        [DisplayName("遞送地址")]
        [Required(ErrorMessage = "請輸入您的遞送地址")]
        public string ContactAddress { get; set; }

        [DisplayName("訂單金額")]
        [Required]
        [DataType(DataType.Currency)]
        [Description("由於訂單金額可能會因遞送方式或優惠折扣等方式異動價格，因此要保留購買當下算出來的金額")]
        public int TotalPrice { get; set; }

        [DisplayName("訂單備註")]
        [DataType(DataType.MultilineText)]
        public string memo { get; set; }

        [DisplayName("訂單時間")]
        [DataType(DataType.MultilineText)]
        public DateTime BuyOn { get; set; }

        [NotMapped]
        public string Displayname {
            get { return this.Member.Name + "於" + this.BuyOn + "訂購的商品"; }
        }

        public virtual ICollection<OrderDetail> OrderDetailItems { get; set; }

        //public virtual Member Member { get; set; }
    }
}