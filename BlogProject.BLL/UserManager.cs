using BlogProject.DAL.EntityFramework;
using BlogProject.Entities;
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
            BusinessLayerResult<User> layerResult = new BusinessLayerResult<User>();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    layerResult.Errors.Add("Kayıtlı kullanıcı adı");
                }
                if (user.Email == data.Email)
                {
                    layerResult.Errors.Add("Kayıtlı email adresi");
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
                    layerResult.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);
                    //TODO: Aktivasyo mail'i atılacak
                    //layerResult.Result.ActivateGuid
                }
            }
            return layerResult;
        }
    }
}
