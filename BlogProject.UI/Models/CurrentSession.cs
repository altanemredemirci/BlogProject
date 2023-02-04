using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.UI.Models
{
    public  class CurrentSession //Session Helper
    {
        public static User User
        {
            get
            {
                return Get<User>("login");
            }
        }

        //verilen key anhatar değerine göre oturum açma işlemi
        public static void Set<T> (string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        //verilen key değerine atanmış oturum bilgisi getirme işlemi
        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }
            return default(T);
        }

        //verilen key anahtarındaki oturumu silme
        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }           
        }
        
        //Açık olan oturumları hepsini silme
        public static void Clear()
        {
                HttpContext.Current.Session.Clear();
            
        }
    }
}