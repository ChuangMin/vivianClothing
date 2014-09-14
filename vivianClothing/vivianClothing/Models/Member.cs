using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace vivianClothing.Models
{
    [DisplayName("會員資料")]
    [DisplayColumn("Name")]
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("會員帳號")]
        [Required(ErrorMessage="請輸入E-mail地址")]
        [Description("我們將會以您的E-mail作為登入帳號")]
        [MaxLength(250,ErrorMessage="不能超過250個字")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckDup","Member",HttpMethod="POST",ErrorMessage="您輸入的Email已經有人註冊過了")]
        public string Email { get; set; }


        [DisplayName("會員密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [Description("密碼將會加密請您放心")]
        [MaxLength(40, ErrorMessage = "不能超過40個字")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("中文姓名")]
        [Required(ErrorMessage = "請輸入中文姓名")]
        [Description("目前以中文為主")]
        [MaxLength(5, ErrorMessage = "中文姓名不能超過5個字")]
        public string Name { get; set; }

        [DisplayName("會員註冊時間")]
        public string RegisterOn { get; set; }

        [DisplayName("會員啟用認證碼")]
        [Description("當 Auto code = Null 代表已經通過驗證")]
        [MaxLength(36)]
        public string AutoCode { get; set; }

        public virtual ICollection<OrderHeader> Orders { get; set; }
    }
}