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
                    IsActive=false,
                    IsAdmin=false
                });

                if (dbResult > 0)
                {
                    res.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);
                    //TODO: Aktivasyo mail'i atılacak
                    //layerResult.Result.ActivateGuid
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
    }
}
