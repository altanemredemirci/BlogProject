using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.WEBUI.ViewModels
{
    public class InfoViewModel:NotifyViewModel<string>
    {
        public InfoViewModel()
        {
            Title = "Bilgilendirme";
        }
    }
}