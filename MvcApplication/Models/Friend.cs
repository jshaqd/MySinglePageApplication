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
    public class Friend : Entity
    {
        public Friend()
        {
            Created = DateTime.Now;
        }

        [JsonProperty(PropertyName = "created")]
        [Display(Name = "时间")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请填入姓名.")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "state")]
        [Display(Name = "籍贯")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "employer")]
        [Display(Name = "工作单位")]
        public string Employer { get; set; }

        [JsonProperty(PropertyName = "highschool")]
        [Display(Name = "中学")]
        public string HighSchool { get; set; }

        [JsonProperty(PropertyName = "college")]
        [Display(Name = "大学")]
        public string College { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        [Display(Name = "电话")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "url")]
        [Display(Name = "主页")]
        public string URL { get; set; }
    }
}