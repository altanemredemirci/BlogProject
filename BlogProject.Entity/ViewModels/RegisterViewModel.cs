using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BlogProject.Entity.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez."),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password),StringLength(10,ErrorMessage ="{0} max. {1} karakter olmalı")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password),StringLength(10, ErrorMessage = "{0} max. {1} karakter olmalı")]
        [Compare("Password",ErrorMessage ="Şfreleriniz uyuşmuyor..")]
        public string RePassword { get; set; }
    }
}