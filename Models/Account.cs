using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginWithRememberMe.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        [Display(Name="Kullanıcı Adı")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}