using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MvcApplication.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OrderForm : Entity
    {
        public OrderForm()
        {
            Created = DateTime.Now;
        }

        [JsonProperty(PropertyName = "created")]
        [Display(Name = "时间")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "companyname")]
        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "address")]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "phonenumber")]
        [Display(Name = "电话 *")]
        [Required(ErrorMessage = "请输入电话.")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "faxnumber")]
        [Display(Name = "传真")]
        public string FaxNumber { get; set; }

        [JsonProperty(PropertyName = "contactname")]
        [Display(Name = "联系人 *")]
        [Required(ErrorMessage = "请输入联系人.")]
        public string ContactName { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Display(Name = "电子邮件 *")]
        [Required(ErrorMessage = "请输入电子邮件地址.")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "orderdetail")]
        [Display(Name = "订购详细说明*")]
        [Required(ErrorMessage = "请留言.")]
        public string OrderDetail { get; set; }
    }
}