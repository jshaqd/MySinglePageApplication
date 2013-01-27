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
    public class Comment : Entity
    {
        public Comment()
        {
            Created = DateTime.Now;
        }

        [JsonProperty(PropertyName = "created")]
        [Display(Name = "时间")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请输入姓名.")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "emailaddress")]
        [Display(Name = "E-mail")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "url")]
        [Display(Name = "URL")]
        public string URL { get; set; }

        [JsonProperty(PropertyName = "content")]
        [Display(Name = "留言")]
        [Required(ErrorMessage = "请留言.")]
        public string Content { get; set; }
    }
}