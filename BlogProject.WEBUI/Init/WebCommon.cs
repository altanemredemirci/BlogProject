using BlogProject.Common;
using BlogProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.WEBUI.Init
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

            return null;
        }
    }
}