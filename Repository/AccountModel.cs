using LoginWithRememberMe.Data;
using LoginWithRememberMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginWithRememberMe.Repository
{
    public class AccountModel
    {
        AccountContext cont = new AccountContext();
        public bool login(string username, string password)
        {
          string ad="", sifre="";
            var i = from u in cont.Account where username == u.Username select u;
           foreach(Account s in i)
           {
               ad = s.Username;
               sifre = s.Password;
           }
            return username.Equals(ad) && password.Equals(sifre);
        }
    }
}