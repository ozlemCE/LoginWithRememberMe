using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginWithRememberMe.Models;
using System.ComponentModel.DataAnnotations;

namespace LoginWithRememberMe.ViewModels
{
    public class AccountViewModel
    {
        public Account account { get; set; }
        [Display(Name="Beni Hatırla")]
        public bool remember { get; set; }

    }
}