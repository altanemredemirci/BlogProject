using BlogProject.Common;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.UI.Init
{
    public class WebCommon : ICommon
    {
        public string GetUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                User user = HttpContext.Current.Session["login"] as User;
                return user.Username;
            }

            return "system";
        }
    }
}