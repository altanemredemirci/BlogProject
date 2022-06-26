using BlogProject.Common.Helpers;
using BlogProject.DAL.EntityFramework;
using BlogProject.Entities;
using BlogProject.Entities.Messages;
using BlogProject.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class UserManager
    {
        private Repository<User> repo_user = new Repository<User>();
        public BusinessLayerResult<User> RegisterUser(RegisterViewModel data)
        {
            // Kullanıcı username kontrolü
            // Kullanıcı e-mail kontrolü
            // Kayıt işlemi..
            // Aktivasyon emaili gönderimi

            User user = repo_user.Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kayıtlı kullanıcı adı");
                    
                }
                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Kayıtlı email adresi");                   
                }
            }
            else
            {
                int dbResult = repo_user.Insert(new User()
                {
                    Username=data.Username,
                    Email=data.Email,
                    Password=data.Password,
                    ActivateGuid=Guid.NewGuid(),   
                    ProfileImageFileName="user.png",
                    IsActive=false,
                    IsAdmin=false
                });

                if (dbResult > 0)
                {
                    res.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);

                    string siteUrl = ConfigHelper.Get<string>("SiteRootUrl");
                    string activaUrl = $"{siteUrl}Home/UserActivate/{res.Result.ActivateGuid}";
                    string body = $"Merhaba {res.Result.Username};<br><br>Hesabınızı aktifleştirmek için <a href='{activaUrl}' target='_blank'>tıklayınız</a>";

                    MailHelper.SendMail(body, res.Result.Email, "Blog Project Hesap Aktifleştirme");
                }
            }
            return res;
        }

        public BusinessLayerResult<User> LoginUser(LoginViewModel data)
        {
            //Giriş Kontrolü
            //Hesap aktive edilmiş mi?

            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = repo_user.Find(x => x.Username == data.Username && x.Password == data.Password);

            if (res.Result != null)
            {
                if (!res.Result.IsActive) //res.Resut.IsActive==false
                {
                    res.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir.");
                    res.AddError(ErrorMessageCode.CheckYourEail, "Lütfen Email adresinizi kontrol ediniz.");
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı veya şifre hatası.");
            }

            return res;
       

        }

        public BusinessLayerResult<User> ActivateUser(Guid activateId)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = repo_user.Find(x => x.ActivateGuid == activateId);

            if (res.Result != null)
            {
                if (res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserAlreadyActivate, "Kullanıcı zaten aktif edilmiştir.");
                    return res;
                }

                res.Result.IsActive = true;
                repo_user.Update(res.Result);
            }
            else
            {
                res.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirilecek kullanıcı bulunamadı");
            }

            return res;
        }

        public BusinessLayerResult<User> GetUserById(int? id)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            if (id == null)
            {
                res.AddError(ErrorMessageCode.UserIsNotFound, "Kullanıcı bulunamadı");                
            }
            else
            {
                res.Result = repo_user.Find(x => x.Id == id);

                if (res.Result == null)
                {
                    res.AddError(ErrorMessageCode.UserIsNotFound, "Kullanıcı bulunamadı");
                }
            }
           
            return res;

        }
    }
}
